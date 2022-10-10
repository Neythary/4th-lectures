using Buecher_6700970.Models;
using BuchDatenbank;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.Configuration;

namespace Buecher_6700970.Controllers
{
    public class BuchController : Controller 

        // ermöglicht die Übergabe der Verbindungsparameter mittels DI
    {
        private readonly KonfigurationsLeser _konfigurationsLeser;
        public BuchController(KonfigurationsLeser konfigurationsLeser)
        {
            this._konfigurationsLeser = konfigurationsLeser;
        }

        public string GetConnectionString()
        {
            return _konfigurationsLeser.LiesDatenbankVerbindungZurMariaDB(); 
        }

        public IActionResult Index()
        {

            BuecherListeModel model = LeseDatenInModel(GetConnectionString()); //Daten werden in ein Model eingelesen

            return View(model); //View wird erstellt
        }

        public BuecherListeModel LeseDatenInModel(string connectionString)
        {
            //erstellen zweier Listen, welche die Daten der angezeigten Tabellen beinhaltet
            List<BuchDTO> aktuelleBuecher = new();
            List<BuchDTO> archivierteBuecher = new();

            //Initialisieren des repositorys, in welchem die Datenbankabfragen stattfinden
            var repository = new BuchRepository(connectionString);

            //Auslesen der beiden Tabellen und befüllen der Listen mit den Daten in zwei Unterschiedlichen Threads (zur Parallelisierung)
            Thread aktuelleBuecherLesen = new Thread(() =>
            {
                aktuelleBuecher = repository.HoleAktuelleBuecher();
            });

            Thread archivierteBuecherLesen = new Thread(() =>
            {
                archivierteBuecher = repository.HoleArchivierteBuecher();
            });

            //Ausführen der oben erstellten Threads
            aktuelleBuecherLesen.Start();
            archivierteBuecherLesen.Start();

            aktuelleBuecherLesen.Join();
            archivierteBuecherLesen.Join();

            return new BuecherListeModel(aktuelleBuecher, archivierteBuecher);
        }

        public void Verschieben(BuchDTO buch, string quelle, string ziel)
        {
            string connectionString = GetConnectionString();
            //Repository zum verschieben wird Initialisiert
            var repository = new BuchRepository(connectionString);
            repository.Verschieben(buch, quelle, ziel); //Verschieben des Buches (Löschen aus der 1. Tabelle und Einfügen in die andere Tabelle) wird ausgeführt
        }

        public IActionResult VerschiebeNachAktuell(BuchDTO buch)
        {
            Verschieben(buch, "archivierte_buecher", "aktuelle_buecher"); //Start des verschiebens eines archivierten Buches, zu einem aktuellen Buch

            BuecherListeModel model = LeseDatenInModel(GetConnectionString()); //Neues Laden der beiden Tabellen, nach obiger Verschiebung

            return View("Views/Buch/Index.cshtml", model); //erstellen der View
        }

        public IActionResult VerschiebeNachArchiviert(BuchDTO buch)
        {
            Verschieben(buch, "aktuelle_buecher", "archivierte_buecher"); //Start des verschiebens eines aktuellen Buches, zu einem archivierten Buch

            BuecherListeModel model = LeseDatenInModel(GetConnectionString()); //Neues Laden der beiden Tabellen, nach obiger Verschiebung

            return View("Views/Buch/Index.cshtml", model); //erstellend der View
        }

        // Beim erneuten Versuch die DI umzusetzen kam es zu einem neuartigen Fehler, der nicht auf Fehler in 
        // der Implementierung der DI hinweist
        // Daraufhin wurde alles nochmal umgearbeitet, auch im hinblick auf die Aufgabenstellung Threads für 
        // die Daten einbindung zu verwenden

        /*public IActionResult Index()
        {
            string connectionString = this.GetConnectionString();
            var repository = new BuchRepository(connectionString);
            List<BuchDTO>? buecher = repository.HoleAktuelleBuecher();
           
            var model = new BuecherListeModel(buecher);
            
            return View(model);
        }

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

        // Nimmt das Formular vom Browser entgegen um ein neues Buch einzufügen
        // Der erste if-Zweig fügt ein "aktuelles" Buch ein
        // Der zweite if-Zweig fügt ein "archiviertes" Buch ein
        // Der else-Zweig zeigt die Listen ohne Änderung an
        [HttpPost]
        public IActionResult Einfuegen(BuecherEinfuegenModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Author) && model.Type=="aktiv")
            {
                string connectionString = this.GetConnectionString();
                var repository = new BuchRepository(connectionString);
                repository.FuegeBuchEin(model.Title, model.Author, "aktiv");
                return RedirectToAction(nameof(Index));
            }
            else if (ModelState.IsValid && !string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Author) && model.Type == "archiv")
            {
                string connectionString = this.GetConnectionString();
                var repository = new BuchRepository(connectionString);
                repository.FuegeBuchEin2(model.Title, model.Author, "archiv");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Verschieben()
        {
            var model = new BuecherVerschiebenModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Verschieben(BuecherVerschiebenModel model)
        {
            int id = Int32.Parse(Request.Path.ToString().Split('/').Last());

            if (ModelState.IsValid
                && !string.IsNullOrEmpty(model.Title)
                && !string.IsNullOrEmpty(model.Type))
            {
                string connectionString = this.GetConnectionString();
                var repository = new BuchRepository(connectionString);
                repository.VerschiebenBuch(model.Title, model.Author, model.Type);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }*/

    }
}
