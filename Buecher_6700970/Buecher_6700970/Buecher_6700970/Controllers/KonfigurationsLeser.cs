namespace Buecher_6700970.Controllers
{
    // wird für die Dependency Injection benötigt, und stellt die Verbindungsdaten aus der appsettings.json zur Verfügung
    // nach Aufklärung der gemachten Fehler konnte die DI doch durchgeführt werden.
    // Danach musste der Code vollständig umgebaut werden, da bei der ersten Funktionsimplementierung Fehler der Art 
    // gemacht worden sind, dass die DI zwar die Datenbankverbindung öffnete, aber anschließend einen nicht sehr hilfreichen 
    // Fehler präsentierte. Durch das anpassen des Codes unter Beachtung der gesamten Aufgabenstellung konnte dieser Fehler
    // umgangen werden.

    public class KonfigurationsLeser : IKonfigurationsLeser
    {
        // Übergibt die Verbindungsinformationen für die DB-Verbindung aus der 
        // appsettings.json in die entsprechende Funktion mit der die Verbindung aufgebaut wird.

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

    // Interface um die DI möglich zu machen, welche in der Program.cs entgültig konfiguriert wird
    public interface IKonfigurationsLeser
    {
        public string LiesDatenbankVerbindungZurMariaDB();
    }

}
