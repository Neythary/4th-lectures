using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    class Van : Kombi
    {
        private bool ladeflaeche; 
        public bool GetLadeflaeche()
        {
            Console.WriteLine($"Ladeflaeche vorhanden: {ladeflaeche}.");
            return this.ladeflaeche;
        }

        //Setter
        protected void SetLadeflaeche(bool ladeflaeche)
        {
            this.ladeflaeche = ladeflaeche;
        }

        public Van()
        {
            this.ladeflaeche = false;
            this.SetAnzahlTueren(4);
        }

        public Van(bool ladeflaeche)
        {
            if (ladeflaeche == true)
            {
                this.SetAnzahlTueren(2);
            }
            else
            {
                Console.WriteLine("Anzahl der Tueren unbekannt.");
                
            }
    	}
    }
}
