using BuchDatenbank;

namespace Buecher_6700970.Models
{
    public class BuecherListeModel
    {
        // Legt zwei neue Listen an in die die Bücher durch das Model eingesetzt werden
        public List<BuchDTO> Aktive { get; set; } = new();
        public List<BuchDTO> Archiviert { get; set; } = new();

        // Fügt in beide Listen die jeweils in der Datenbank vorhandenen Bücher ein 
        // unter zur Hilfe nahme des Datentransferobjekts
        public BuecherListeModel(IEnumerable<BuchDTO> aktuelleBuecher, IEnumerable<BuchDTO> archivierteBuecher)
        {
            foreach (BuchDTO buchDTO in aktuelleBuecher)
            {
                Aktive.Add(buchDTO);
            }

            foreach (BuchDTO buchDTO in archivierteBuecher)
            {
                Archiviert.Add(buchDTO);
            }
        }

        // Beim erneuten Versuch die DI umzusetzen kam es zu einem neuartigen Fehler, der nicht auf Fehler in 
        // der Implementierung der DI hinweist
        // Daraufhin wurde alles nochmal umgearbeitet, auch im hinblick auf die Aufgabenstellung Threads für 
        // die Daten einbindung zu verwenden

        /*
        // Model um die Bücher aus der Datenbank bzw. die Datenbankobjekte (DTO) in Listen zu übertragen
        // Für Aktiv & Archiv jeweils separate Listen, der Parameter Type wird in der Klasse definiert und wird
        // aus diesem Grund hier nicht gesetzt über das DTO
        public BuecherListeModel(IEnumerable<BuchDTO> buecher)
        {
            foreach (var buecherDTO in buecher)
            {
                if (buecherDTO.type == "aktiv")
                {
                    var buch = new Aktiv()
                    { id = buecherDTO.Id, title = buecherDTO.title, author = buecherDTO.author };
                    this.Aktive.Add(buch);
                }
                else if (buecherDTO.type == "archiv")
                {
                    var buch1 = new Archiv()
                    { id = buecherDTO.Id, title = buecherDTO.title, author = buecherDTO.author };
                    this.Archiviert.Add(buch1);
                }
            }            
        }
        */

    }
}
