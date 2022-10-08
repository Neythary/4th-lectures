using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuecherDatenbank
{
    public class BuecherDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; } 
        public string? Archiv { get; set; }
    }
}
