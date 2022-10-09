using Buecher_6700970.Models;
using BuchDatenbank;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.Configuration;

namespace Buecher_6700970.Controllers
{
    public class BuchController : Controller 
    {

        // Anweisung um die notwendigen Verbindungsinformationen an die Funktion zum Abrufen der Bücherliste bereitzustellen
        // Auserdem wird die dabei erstellte Liste durch diesen Aufruf an das Model übergeben um auf der Website angezeigt zu werden.
        public IActionResult Index()
        {
            string connectionString = this.GetConnectionString();
            var repository = new BuchRepository(connectionString);
            List<BuchDTO>? buecher = repository.HoleAktuelleBuecher();
           
            var model = new BuecherListeModel(buecher);
            
            return View(model);
        }

        /*public IActionResult Index2()
        {
            string connectionString = this.GetConnectionString();
            var repository = new BuchRepository(connectionString);
            List<BuchDTO>? buecher1 = repository.HoleArchivBuecher();

            var model = new BuecherListeModel(buecher1);

            return View(model);
        }*/

        // Versuch die DB-Verbindung mittels Dependency Injection zu verwirklichen schlug fehl, dafür 
        // sind die beiden nachfolgenden auskommentierten Aufrufe gedacht gewesen.

        
        
        //private string GetConnectionString()
        //{
        //    return _konfigurationsLeser.LiesDatenbankVerbindungZurMariaDB();
        //}

        // Verbindunsinfomationen für den Aufbau der Datenbankverbindung - Hard Codiert.
        private string GetConnectionString()
        {
            
                return "Server=localhost;User ID=admin;Password=admin;Database=BuecherDB;";
            
            
        }


        // Erzeugt das Model für das Eingabe-Formular um neue Bücher in die DB einzufügen
        [HttpGet]
        public IActionResult Einfuegen()
        {
            var model = new BuecherEinfuegenModel();
            return View(model);
        }

        // Nimmt das Formular vom Browser entgegen
        [HttpPost]
        public IActionResult Einfuegen(BuecherEinfuegenModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Author))
            {
                string connectionString = this.GetConnectionString();
                var repository = new BuchRepository(connectionString);
                repository.FuegeBuchEin(model.Title, model.Author);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Einfuegen2(BuecherEinfuegenModel model)
        {
            if(ModelState.IsValid && !string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Author))
            {
                string connectionString = this.GetConnectionString();
                var repository = new BuchRepository(connectionString);
                repository.FuegeBuchEin2(model.Title, model.Author);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }
}
