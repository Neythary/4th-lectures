using FahrzeugDatenbank;
using Fahrzeuge;
using FahrzeugeMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FahrzeugeMVC.Controllers
{
    public class FahrzeugController : Controller
    {
       

        public IActionResult Index()
        {
            string connectionString = this.GetConnectionString();
            var repository = new FahrzeugRepository(connectionString);
            List<FahrzeugDTO>? fahrzeuge = repository.HoleAlleFahrzeuge();

            var model = new FahrzeugListeModel(fahrzeuge);

            return View(model);
        }

        private string GetConnectionString()
        {
            return "Server=localhost;User ID=root;Password=root;Database=FahrzeugDB;";
        }

        [HttpGet]
        public IActionResult Einfuegen()
        {
            var model = new FahrzeugEinfuegenModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Einfuegen(FahrzeugEinfuegenModel model)
        {
            if (ModelState.IsValid
                && !string.IsNullOrEmpty(model.Name)
                && !string.IsNullOrEmpty(model.Type))
            {
                string connectionString = this.GetConnectionString();
                var repository = new FahrzeugRepository(connectionString);
                repository.FuegeFahrzeugEin(model.Name, model.Type);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }



        [HttpGet]
        public IActionResult Loeschen()
        {
            var model = new FahrzeugLoeschenModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Loeschen(FahrzeugLoeschenModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = this.GetConnectionString();
                var repository = new FahrzeugRepository(connectionString);
                repository.LoescheFahrzeug(model.id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public IActionResult Suche(string suche)
        {
            if (string.IsNullOrEmpty(suche))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string connectionString = this.GetConnectionString();
                var repository = new FahrzeugRepository(connectionString);
                List<FahrzeugDTO>? fahrzeuge = repository.HoleAlleFahrzeuge();

                IEnumerable<FahrzeugDTO>? gefilterteFahrzeuge = fahrzeuge
                    .Where(fahrzeug => !string.IsNullOrEmpty(suche)
                        && fahrzeug.Name != null
                        && fahrzeug.Name
                        .ToLower()
                        .Contains(suche.ToLower()));

                var model = new FahrzeugListeModel(gefilterteFahrzeuge);

                return View("index", model);
            }
        }
        [HttpGet]
        public IActionResult Aktualisieren()
        {
            var model = new FahrzeugAktualisierenModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Aktualisieren(FahrzeugAktualisierenModel model)
        {
            int id = Int32.Parse(Request.Path.ToString().Split('/').Last());

            if (ModelState.IsValid
                && !string.IsNullOrEmpty(model.Name)
                && !string.IsNullOrEmpty(model.Type))
            {
                string connectionString = this.GetConnectionString();
                var repository = new FahrzeugRepository(connectionString);
                repository.AktualisierenFahrzeug(id, model.Name, model.Type);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }

}
