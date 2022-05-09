using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahrzeugeMVC.Models
{
    public class FahrzeugAktualisierenModel
    {
        

       
        public string? Name { get; set; }

        
        public string? Type { get; set; }

        public List<SelectListItem> FahrzeugTypen { get; private set; } = new()
        {
            new SelectListItem("Auto", "Auto", true),
            new SelectListItem("Motorrad", "Motorrad"),
            new SelectListItem("Fahrrad", "Fahrrad")
        };
    }

    
}
 