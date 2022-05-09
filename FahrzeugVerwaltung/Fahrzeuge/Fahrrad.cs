
namespace Fahrzeuge
{
    public class Fahrrad : Fahrzeug
    {
        public Fahrrad()
        {
            base.AnzahlRaeder = 2;
            base.ReifenTyp = "Strassenreifen";
        }

        public override void WechsleReifenTyp()
        {
            if (base.ReifenTyp == "Strassenreifen")
            {
                base.ReifenTyp = "Rennreifen";
            }
            else
            {
                base.ReifenTyp = "Strassenreifen";
            }
        }
    }
}
