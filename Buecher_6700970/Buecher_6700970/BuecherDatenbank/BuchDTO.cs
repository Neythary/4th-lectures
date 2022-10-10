using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchDatenbank
{
    // Parameter für die Buch Datenbankobjekte, die für die Übertragung der DB-Daten in die Model-Liste notwendig sind
    public class BuchDTO
    {
        public string? title { get; set; }
        public string? author { get; set; }
    }
}
