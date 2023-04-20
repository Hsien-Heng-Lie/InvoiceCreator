using InvoiceCreator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceCreator.Controllers
{
    public partial class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}