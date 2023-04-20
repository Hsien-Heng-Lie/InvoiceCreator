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
            //ViewData["Questions"] = DatabaseHandler.getQuestions();
            ViewData["T"] = DatabaseHandler.getTransactions();
            return View();
        }
    }
}
