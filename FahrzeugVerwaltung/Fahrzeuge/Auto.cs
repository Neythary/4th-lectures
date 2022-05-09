
namespace Fahrzeuge
{
    public class Auto : Fahrzeug, IAuftankbar
    {
        public Auto()
        {
            base.AnzahlRaeder = 4;
            base.ReifenTyp = "Sommer";
        }

        private bool istAufgetankt = false;

        public void Auftanken()
        {
            this.istAufgetankt = true;
        }

        public override void WechsleReifenTyp()
        {
            if (base.ReifenTyp == "Sommer") 
            {
                base.ReifenTyp = "Winter"; 
            }
            else
            {
                base.ReifenTyp = "Sommer"; 
            }
        }
    }
}


namespace Fahrzeuge
{
    public class Auto2 : Fahrzeug
    {
        public Auto2()
        {
            base.AnzahlRaeder = 4;
            base.ReifenTyp = "Sommer";
        }

        public override void WechsleReifenTyp()
        {
            if (base.ReifenTyp == "Sommer")
            {
                base.ReifenTyp = "Winter";
            }
            else
            {
                base.ReifenTyp = "Sommer";
            }
        }
    }
}

