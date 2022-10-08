using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    public class AktivBuch : Buch
    {
        public AktivBuch()
        {
          
        }

        public AktivBuch(string title, string author)
        {
            this.title = title;
            this.author = author;
        }
    }
}
