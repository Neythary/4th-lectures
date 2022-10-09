using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    // initialisiert die Klasse Aktiv als Kind von Buch mit entsprechendem Type-Attribut
    public class Aktiv : Buch
    {
        public Aktiv()
        {
            base.type = "aktiv";
        }

    }
}
