using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    public class Aktiv : Buch
    {
        public Aktiv()
        {
            base.title = "";
            base.author = "";
            base.type = "aktiv";
        }

    }
}
