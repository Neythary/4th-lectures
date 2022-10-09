using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buecher_6700970.Models
{
    // Model zum Einfügen von neuen Büchern über ein Formular
    public class BuecherEinfuegenModel
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? Type { get; set; }


        // Richtet für den Parameter "Type" eine Dropdownliste ein, sodass nur die erwünschten Typen eingetragen werden können
        public List<SelectListItem> BuchTypen { get; private set; } = new()
            {
                new SelectListItem("aktiv", "aktiv", true),
                new SelectListItem("archiv", "archiv")
            };

      
    }
}
