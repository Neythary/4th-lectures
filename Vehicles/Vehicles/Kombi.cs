using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    class Kombi : Auto
    {
        public Kombi()
        {
            this.SetAnzahlTueren(5);
        }

        public Kombi(int anzahlTueren)
        {
            this.SetAnzahlTueren(5);
        }
    }
}
