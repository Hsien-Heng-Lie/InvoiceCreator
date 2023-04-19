using InvoiceCreator.Controllers;
using InvoiceCreator.Helpers;
using InvoiceCreator.Models;
using InvoiceCreator.StaticData;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreatorFrontend.Controllers
{
    public class InvoiceController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private List<TransactionsModel> transactions;
        private PaginationHelper pagination;

        public IActionResult PaginationNext()
        {

            pagination._currentPage = pagination._currentPage + 1;
            ViewBag.PageNumber = pagination._currentPage;
            return View("ViewTransaction", pagination.GetPageByNumber(transactions, pagination._currentPage));
        }

        public IActionResult PaginationPrevious()
        {
            pagination._currentPage--;
            ViewBag.PageNumber = pagination._currentPage;
            return View("ViewTransaction", pagination.GetPageByNumber(transactions, pagination._currentPage));
        }

        public InvoiceController(ILogger<HomeController> logger)
        {
            _logger = logger;
            transactions = TransactionsData.Transactions;
            pagination = new PaginationHelper(5, 1, transactions.Count);
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

            ViewBag.PageNumber = pagination._currentPage;
            return View(pagination.GetPageByNumber(transactions, pagination._currentPage));
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
