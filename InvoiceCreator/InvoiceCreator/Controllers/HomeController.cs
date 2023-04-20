﻿using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreator.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Set navbar indicator location
            ViewBag.indicatorOpacity = "0";
            
            return View();
        }
    }
}