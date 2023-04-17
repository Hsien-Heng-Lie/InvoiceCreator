using InvoiceCreator.Models;
using InvoiceCreator.StaticData;
using InvoiceCreator.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Transactions;

namespace InvoiceCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<TransactionsModel> transactions;
        private PaginationHelper pagination;

        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            transactions =  TransactionsData.Transactions;
            pagination = new PaginationHelper(5, 1, transactions.Count);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewTransaction(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if(!String.IsNullOrEmpty(searchString))
            {
                transactions = transactions.Where(s => s.Student.FirstName.Contains(searchString) || s.Student.LastName.Contains(searchString)).ToList();
            }

            ViewBag.PageNumber = pagination._currentPage;
            return View(pagination.GetPageByNumber(transactions,pagination._currentPage));
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        public IActionResult PaginationNext() 
        {

            pagination._currentPage = pagination._currentPage + 1;
            ViewBag.PageNumber = pagination._currentPage;
            return View("ViewTransaction",pagination.GetPageByNumber(transactions, pagination._currentPage));
        }

        public IActionResult PaginationPrevious()
        {
            pagination._currentPage--; 
            ViewBag.PageNumber = pagination._currentPage;
            return View("ViewTransaction", pagination.GetPageByNumber(transactions, pagination._currentPage));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}