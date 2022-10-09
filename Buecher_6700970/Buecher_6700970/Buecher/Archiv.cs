using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    // initialisiert die Klasse Archiv als Kind von Buch mit dem entsprechenden Typ-Attribut
    public class Archiv : Buch
    {
        public Archiv()
        {
            base.type = "archiv";
        }        
        
    }
}
