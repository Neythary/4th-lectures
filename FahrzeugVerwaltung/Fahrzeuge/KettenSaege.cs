
namespace Fahrzeuge
{
    public class KettenSaege : IAuftankbar
    {
        private bool istAufgetankt = false;

        public void Auftanken()
        {
            this.istAufgetankt = true;
        }
    }
}
