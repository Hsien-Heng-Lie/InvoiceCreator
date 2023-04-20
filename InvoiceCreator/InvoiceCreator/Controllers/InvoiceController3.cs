using InvoiceCreator.Controllers;
using InvoiceCreator.Data;
using InvoiceCreator.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace InvoiceCreatorFrontend.Controllers
{
    public partial class InvoiceController : Controller
    {
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

        public IActionResult AddInvoice(string student, string difficulty, string levelupName, string question)
        { //THE SPECIFIC ADDITION CODE return View("CreateInvoice"); }
            if(student == null || difficulty == null || levelupName == null)
            {
                return RedirectToAction("CreateInvoice");
            }
            
            string studentId = student.Split('.')[0];
            string difficultyId = difficulty.Split('.')[0];
            string levelupNameId = levelupName.Split('.')[0];

            DatabaseHandler.addQuestion(studentId, difficultyId, levelupNameId, question);
            return RedirectToAction("CreateInvoice");
        }
    }
}
