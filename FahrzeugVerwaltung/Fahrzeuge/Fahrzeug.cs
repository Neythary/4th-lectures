
namespace Fahrzeuge
{
    public abstract class Fahrzeug
    {
        public Fahrzeug()
        {
            this.ReifenTyp = "";
        }

        public string? Name { get; set; }
        public int Id { get; set; }

        public int AnzahlRaeder { get; protected set; }

        public string ReifenTyp { get; protected set; }

        public abstract void WechsleReifenTyp();

        public virtual void SetzeAnzahlRaeder(int anzahlDerRaeder)
        {
            if (anzahlDerRaeder < 0) return;
            this.AnzahlRaeder = anzahlDerRaeder;
        }
    }
}


namespace Fahrzeuge
{
    public class Fahrzeug2
    {
        public Fahrzeug2()
        {
            this.SetAnzahlRaeder(4);
        }

        public Fahrzeug2(int anzahlDerReader)
        {
            this.SetAnzahlRaeder(anzahlDerReader);
        }

        private int anzahlRaeder;

        public int GetAnzahlRaeder()
        {
            return this.anzahlRaeder;
        }

        protected void SetAnzahlRaeder(int anzahlDerReader)
        {
            this.anzahlRaeder = anzahlDerReader;
        }
    }
}

namespace Fahrzeuge
{
    public class Fahrzeug3
    {
        public Fahrzeug3()
        {
            this.AnzahlRaeder = 4;
        }

        public Fahrzeug3(int anzahlDerReader)
        {
            this.AnzahlRaeder = anzahlDerReader;
        }

        public int AnzahlRaeder { get; protected set; }
    }
}


