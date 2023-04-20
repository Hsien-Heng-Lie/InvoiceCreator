using InvoiceCreator.Controllers;
using InvoiceCreator.Models;
using InvoiceCreator.Data;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreatorFrontend.Controllers
{
    public partial class InvoiceController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private List<TransactionsModel> transactions;

        public delegate void emailSend(string email, string name, int transId);

        public InvoiceController(ILogger<HomeController> logger)
        {
            _logger = logger;
            transactions = DatabaseHandler.getTransactions();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}