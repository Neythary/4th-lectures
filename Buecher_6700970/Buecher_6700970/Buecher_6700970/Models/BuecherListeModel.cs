using Buecher;
using BuchDatenbank;

namespace Buecher_6700970.Models
{
    public class BuecherListeModel
    {
     
        public BuecherListeModel(IEnumerable<BuchDTO> buecher)
        {
            foreach (var buecherDTO in buecher)
            {
                var buch = new Buch()
                { id = BuchDTO.Id, title = BuchDTO.title, author = BuchDTO.author };
                this.Buecher.Add(buch);
            }          
        }
        public List<Buch> Buecher { get; set; } = new();
    }
}
