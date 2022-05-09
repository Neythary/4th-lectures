
namespace Fahrzeuge
{
    public class Motorrad : Fahrzeug, IAuftankbar
    {
        public Motorrad()
        {
            base.AnzahlRaeder = 2;
            base.ReifenTyp = "schmal";
        }

        private bool istAufgetankt = false;

        public void Auftanken()
        {
            this.istAufgetankt = true;
        }

        public override void WechsleReifenTyp()
        {
            if (base.ReifenTyp == "schmal")
            {
                base.ReifenTyp = "breit";
            }
            else
            {
                base.ReifenTyp = "schmal";
            }
        }
    }
}


namespace Fahrzeuge
{
    public class Motorrad2 : Fahrzeug
    {
        public Motorrad2()
        {
            base.AnzahlRaeder = 2;
            base.ReifenTyp = "schmal";
        }

        public override void WechsleReifenTyp()
        {
            if (base.ReifenTyp == "schmal")
            {
                base.ReifenTyp = "breit";
            }
            else
            {
                base.ReifenTyp = "schmal";
            }
        }
    }
}

