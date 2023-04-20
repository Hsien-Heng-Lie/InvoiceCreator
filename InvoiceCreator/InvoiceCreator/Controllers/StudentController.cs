using Microsoft.AspNetCore.Mvc;
using InvoiceCreator.Data;

namespace InvoiceCreatorFrontend.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AddStudent(string FirstName, string LastName, int GradYear, string Email )
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "53%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "3";
            if (FirstName != null && LastName != null && GradYear != null && Email != null) { 
            DatabaseHandler.addStudent(FirstName, LastName, GradYear, Email);
            }
            return View();
        }
    }
}
