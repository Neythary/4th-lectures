﻿using Microsoft.AspNetCore.Mvc;
using Programmentwurf_6700970.Models;
using System.Diagnostics;

namespace Programmentwurf_6700970.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //GET /Programmentwurf_6700970/Index/
        public IActionResult Index()
        {
            return View();
        }


        //GET /Programmentwurf_6700970/Privacy/
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}