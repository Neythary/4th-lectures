namespace Buecher_6700970.Controllers
{
    // wird für die Dependency Injection benötigt, und stellt die Verbindungsdaten aus der appsettings.json zur Verfügung

    // nach Rücksprache mit Kollegen konnte die implementierung der DI durchgeführt werden.
    public class KonfigurationsLeser : IKonfigurationsLeser
    {
        private readonly IConfiguration _configuration;

        public KonfigurationsLeser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string LiesDatenbankVerbindungZurMariaDB()
        {
            return _configuration.GetConnectionString("MariaDB");
        }

    }

    public interface IKonfigurationsLeser
    {
        public string LiesDatenbankVerbindungZurMariaDB();
    }

}
