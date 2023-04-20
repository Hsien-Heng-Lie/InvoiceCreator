using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreatorFrontend.Controllers
{
    public class LevelUpController : Controller
    {
        public IActionResult AddLevelUp(string LevelUpName, string startDate, string endDate)
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "77.5%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "4";
            
            return View();
        }

    }
}
