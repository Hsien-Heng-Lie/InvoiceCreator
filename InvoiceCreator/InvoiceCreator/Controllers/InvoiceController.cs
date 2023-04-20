﻿using InvoiceCreator.Controllers;
using InvoiceCreator.Models;
using InvoiceCreator.StaticData;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
