using InvoiceCreator.Controllers;
using InvoiceCreator.Models;
using InvoiceCreator.StaticData;
using InvoiceCreator.Helpers;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace InvoiceCreatorFrontend.Controllers
{
    public class InvoiceController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private List<TransactionsModel> transactions;

        public InvoiceController(ILogger<HomeController> logger)
        {
            _logger = logger;
            transactions = TransactionsData.Transactions;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewTransaction(string searchString, string currentFilter, int? page)
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "2.5%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "1";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                transactions = transactions.Where(s => s.Student.FirstName.Contains(searchString) || s.Student.LastName.Contains(searchString)).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(transactions.ToPagedList(pageNumber, pageSize));
            //return View(pagination.GetPageByNumber(transactions, pagination._currentPage));
        }

        public IActionResult DownloadPDF(int transID) 
        {
            Document document = PDFHelper.GeneratePDF(transID);
            var memoryStream = new System.IO.MemoryStream();
            document.Draw(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return File(bytes, "application/pdf", "myPdf.pdf");
        }

        // shouldsend return on or off. not true or false.
        public IActionResult CreateInvoice(string student, string difficulty, string levelup, string question,string shouldSend)
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "28%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "2";

            return View();
        }
    }
}
