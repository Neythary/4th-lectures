using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Programmentwurf_6700970.Models
{
    public class EinfuegenModel
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        public List<SelectListItem> BuecherTypen { get; private set; } = new()
        {
            new SelectListItem("Aktiv", "Aktiv", true),
            new SelectListItem("Archiv", "Archiv"),
        };
    }
}
