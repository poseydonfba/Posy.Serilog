﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Posy.Serilog.Models;
using System;
using System.Diagnostics;

namespace Posy.Serilog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Acesso a Home/Index");

            return View();
        }

        public IActionResult Privacy()
        {
            throw new NotImplementedException("Erro de teste Serilog");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
