using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    public class ArchivBuch : Buch
    {
        public ArchivBuch()
        {
            
        }

        public ArchivBuch(string title, string author)
        {
            this.title = title;
            this.author = author;
        }
    }
}
