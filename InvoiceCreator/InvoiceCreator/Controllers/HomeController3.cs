using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreator.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }
    }
}