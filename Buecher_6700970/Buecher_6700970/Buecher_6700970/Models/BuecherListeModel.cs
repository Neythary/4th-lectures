using Buecher;
using BuchDatenbank;

namespace Buecher_6700970.Models
{
    public class BuecherListeModel
    {
        // Model um die Bücher aus der Datenbank bzw. die Datenbankobjekte (DTO) in Listen zu übertragen
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



        // Legt neue Listen an in die die Bücher aus der DB aufgenommen werden
        public List<Buch> Aktive { get; set; } = new();
 

        public List<Buch> Archiviert { get; set; } = new();    
       
    }
}
