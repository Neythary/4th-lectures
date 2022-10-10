using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buecher_6700970.Models
{
    public class BuecherVerschiebenModel
    {
        public string? Title { get; set; }
        public string? Author { get; set; } 
        public string? Type { get; set; }

        public List<SelectListItem> BuchTypen { get; private set; } = new()
        {
            new SelectListItem("aktiv", "aktiv", true),
            new SelectListItem("archiv", "archiv")
        };

    }
}
