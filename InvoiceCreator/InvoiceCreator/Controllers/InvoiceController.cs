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
    public partial class InvoiceController : Controller
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
    }
}
