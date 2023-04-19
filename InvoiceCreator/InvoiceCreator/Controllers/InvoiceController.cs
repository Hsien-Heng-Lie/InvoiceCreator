using InvoiceCreator.Controllers;
using InvoiceCreator.Models;
using InvoiceCreator.StaticData;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
