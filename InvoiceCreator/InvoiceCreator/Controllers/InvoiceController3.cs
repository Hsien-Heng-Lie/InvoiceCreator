using InvoiceCreator.Controllers;
using InvoiceCreator.Models;
using InvoiceCreator.StaticData;
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
            return View();
        }
    }
}
