using Buecher_6700970.Models;
using BuchDatenbank;
using Microsoft.AspNetCore.Mvc;

namespace Buecher_6700970.Controllers
{
    public class BuchController : Controller
    {
        public IActionResult Index()
        {
            string connectionString = this.GetConnectionString();
            var repository = new BuchRepository(connectionString);
            List<BuchDTO>? buecher = repository.HoleAlleBuecher();

            var model = new BuecherListeModel(buecher);

            return View(model);
        }

        private string GetConnectionString()
        {
            return "Server=localhost;User ID=admin;Password=admin;Database=BuecherDB;";
        }
    }
}
