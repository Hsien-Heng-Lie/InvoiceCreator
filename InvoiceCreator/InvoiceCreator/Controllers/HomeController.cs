using InvoiceCreator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceCreator.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            // Set navbar indicator location
            ViewBag.indicatorOpacity = "0";
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}