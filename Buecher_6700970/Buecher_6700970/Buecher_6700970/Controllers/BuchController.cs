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

        // liest die Verbindungsparameter aus der appsettings.json ein
        public string GetConnectionString()
        {
            return _konfigurationsLeser.LiesDatenbankVerbindungZurMariaDB(); 
        }

        // liest die Daten der DB in ein Model ein und gibt die entsprechende View zurück
        // das Einlesen wird separat implementiert
        public IActionResult Index()
        {
            BuecherListeModel model = LeseDatenInModel(GetConnectionString()); 

            return View(model); 
        }

        // Implementierung der Dateneinlesung, getrennt nach Tabelle in der DB auch hier in zwei verschiedene Tabellen
        // Das Repository ist für alle Datenbankabfragen zuständig und notwendig
        // Das Auslesen der im Repository getätigten Abfragen erfolgt in Form von Threads
        // die parallelisiert das Auslesen übernehmen
        public BuecherListeModel LeseDatenInModel(string connectionString)
        {
            List<BuchDTO> aktuelleBuecher = new();
            List<BuchDTO> archivierteBuecher = new();
            var repository = new BuchRepository(connectionString);

            Thread aktuelleBuecherLesen = new Thread(() =>
            {
                aktuelleBuecher = repository.HoleAktuelleBuecher();
            });

            Thread archivierteBuecherLesen = new Thread(() =>
            {
                archivierteBuecher = repository.HoleArchivierteBuecher();
            });

            aktuelleBuecherLesen.Start();
            archivierteBuecherLesen.Start();

            aktuelleBuecherLesen.Join();
            archivierteBuecherLesen.Join();

            return new BuecherListeModel(aktuelleBuecher, archivierteBuecher);
        }

        // Funktion zum Verschieben von Büchern zwischen den Tabellen der DB
        // über den Umweg des repositorys
        public void Verschieben(BuchDTO buch, string quelle, string ziel)
        {
            string connectionString = GetConnectionString();
            var repository = new BuchRepository(connectionString);
            repository.Verschieben(buch, quelle, ziel); 
        }

        // Implementiert eine Action die über Index.cshtml aufgerufen wird zum verschieben in die Tabelle "aktuelle_buecher"
        // Lädt nach erfolgreichem Verschieben die Tabellen nochmals neu um sie korrekt anzuzeigen
        // und gibt anschließend die entsprechende View aus
        public IActionResult VerschiebeNachAktuell(BuchDTO buch)
        {
            Verschieben(buch, "archivierte_buecher", "aktuelle_buecher"); 
            BuecherListeModel model = LeseDatenInModel(GetConnectionString()); 

            return View("Views/Buch/Index.cshtml", model); 
        }

        // Implementiert eine Action die über Index.cshtml aufgerufen wird zum verschieben in die Tabelle "archivierte_buecher"
        // Lädt nach erfolgreichem Verschieben die Tabellen nochmals neu um sie korrekt anzuzeigen
        // und gibt anschließend die entsprechende View aus
        public IActionResult VerschiebeNachArchiviert(BuchDTO buch)
        {
            Verschieben(buch, "aktuelle_buecher", "archivierte_buecher"); 

            BuecherListeModel model = LeseDatenInModel(GetConnectionString());

            return View("Views/Buch/Index.cshtml", model);
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
