using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreatorFrontend.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AddStudent()
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "53%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "3";
            
            return View();
        }
    }
}
