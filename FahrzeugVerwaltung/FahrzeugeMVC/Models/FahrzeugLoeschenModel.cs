using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahrzeugeMVC.Models
{
    public class FahrzeugLoeschenModel
    {
        [Required]
        public int id { get; set; }
    }

    
}
 