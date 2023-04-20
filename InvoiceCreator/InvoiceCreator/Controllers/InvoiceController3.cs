using InvoiceCreator.Data;
using InvoiceCreator.Helpers;
using Microsoft.AspNetCore.Mvc;
using ceTe.DynamicPDF;
using InvoiceCreatorFrontend.helpers;
using InvoiceCreator.Models;

namespace InvoiceCreatorFrontend.Controllers
{
    public partial class InvoiceController : Controller
    {

        emailSend email = EmailHelper.SendEmail;

        public IActionResult CreateInvoice()
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "28%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "2";

            ViewData["Students"] = DatabaseHandler.getStudents();
            ViewData["LevelUps"] = DatabaseHandler.getLevelUps();
            ViewData["QuestionDifficulties"] = DatabaseHandler.getQuestionDifficulties();

            return View();
        }

        public IActionResult AddInvoice(string student, string difficulty, string levelupName, string question, string shouldSend)
        { //THE SPECIFIC ADDITION CODE return View("CreateInvoice"); }
            if(student == null || difficulty == null || levelupName == null)
            {
                return RedirectToAction("CreateInvoice");
            }
            
            string studentId = student.Split('.')[0];
            string difficultyId = difficulty.Split('.')[0];
            string levelupNameId = levelupName.Split('.')[0];
            List<StudentModel> students = DatabaseHandler.getStudents();
            StudentModel studentMod;
            studentMod = students.Find(s => s.Id == Convert.ToInt32(studentId));
            if (shouldSend == "on")
            {
                email(studentMod.Email, studentMod.FirstName + " " + studentMod.LastName, 1);
            }

            DatabaseHandler.addQuestion(studentId, difficultyId, levelupNameId, question);
            return RedirectToAction("CreateInvoice");
        }

        public IActionResult DownloadPDF(int transID)
        {

            List<StudentModel> students = DatabaseHandler.getStudents();
            StudentModel student;
            student = students.Find(s => s.Id == transID);

            Document document = PDFHelper.GeneratePDF(transID);
            var memoryStream = new System.IO.MemoryStream();
            document.Draw(memoryStream);
            byte[] bytes = memoryStream.ToArray();

            return File(bytes, "application/pdf",student.FirstName +"_"+ student.LastName + "_Invoice.pdf");
        }

        public IActionResult EmailPDF(int studentId)
        {
            List<StudentModel> students = DatabaseHandler.getStudents();
            StudentModel student;
            student = students.Find(s => s.Id == studentId);

            email(student.Email, student.FirstName + student.LastName, student.Id);

            return RedirectToAction("ViewTransaction");
        }
    }
}
