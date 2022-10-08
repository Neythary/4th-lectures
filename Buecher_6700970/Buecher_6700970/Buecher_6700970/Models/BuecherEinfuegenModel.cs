using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buecher_6700970.Models
{
    public class BuecherEinfuegenModel
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? Type { get; set; }

        public List<SelectListItem> BuchTypen { get; private set; }
            = new()
            {
                new SelectListItem("Aktiv", "Aktiv"),
                new SelectListItem("Archiv", "Archiv")
            };

      
    }
}
