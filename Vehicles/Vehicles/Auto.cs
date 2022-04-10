using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    class Auto
    {
        private int anzahlTueren;
        private string carColor;
        private string carType;

        //Konstruktor 1
        public Auto()
        {
            this.SetAnzahlTueren(4);
        }

        //Konstruktor 2
        public Auto(int anzahlTueren)
        {
            this.SetAnzahlTueren(anzahlTueren);
        }

        //Getter
        public int GetAnzahlTueren()
        {
            Console.WriteLine($"Anzahl Tueren: {anzahlTueren}.");
            return this.anzahlTueren;
        }

        public string GetCarColor()
        {
            Console.WriteLine($"Autofarbe: {carColor}.");
            return this.carColor;
        }

        public string GetCarType()
        {
            Console.WriteLine($"Autotyp: {carType}.");
            return this.carType;
        }

        //Setter
        protected void SetAnzahlTueren(int anzahlTueren)
        {
            this.anzahlTueren = anzahlTueren;
        }

        protected void SetCarColor(string carColor)
        {
            this.carColor = carColor;
        }

        protected void SetCarType(string carType)
        {
            this.carType = carType;
        }
    }
}
