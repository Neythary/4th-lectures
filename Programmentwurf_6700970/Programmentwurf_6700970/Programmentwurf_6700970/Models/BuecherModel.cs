using BuecherDatenbank;
using Buecher;

namespace Programmentwurf_6700970.Models
{
    public class BuecherModel
    {
        public BuecherModel(IEnumerable<BuecherDTO> buecher)
        {
            foreach (var buecherDTO in buecher)
            {
                switch (buecherDTO.Archiv)
                {
                    case "ArchivBuch":
                        var archivbuch = new ArchivBuch()
                        { author = buecherDTO.Author, title = buecherDTO.Title };
                        this.Buecher.Add(archivbuch);
                        break;
                    case "AktivBuch":
                        var aktivbuch = new AktivBuch()
                        { author = buecherDTO.Author, title = buecherDTO.Title };
                        this.Buecher.Add(aktivbuch);
                        break;
                }
            }
        }
        public List<Buch> Buecher { get; set; } = new();
    }
}
