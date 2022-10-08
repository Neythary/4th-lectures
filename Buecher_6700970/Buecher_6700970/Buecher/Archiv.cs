using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    public class Archiv : Buch
    {
        public Archiv()
        {
            base.title = "";
            base.author = "";
            base.type = "archiv";
        }

        
    }
}
