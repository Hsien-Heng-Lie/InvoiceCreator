using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreatorFrontend.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
