using Buecher_6700970.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buecher_6700970.Controllers
{
    // Standardmäßig vorhandener Controller, auf den im default-Fall zurück gegriffen wird 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

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