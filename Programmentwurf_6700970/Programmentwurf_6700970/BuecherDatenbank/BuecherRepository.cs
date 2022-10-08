using MySqlConnector;

namespace BuecherDatenbank
{
    public class BuecherRepository
    {
        private string _connectionString;

        public BuecherRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public List<BuecherDTO> HoleBuecher()
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "SELECT buecher_title, buecher_author FROM fahrzeuge";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            var reader = kommando.ExecuteReader();

            List<BuecherDTO> buecher = new();
            while (reader.Read())
            {
                var buch = new BuecherDTO();
                buch.Title = reader.GetString(1);
                buch.Author = reader.GetString(2);

                buecher.Add(buch);
            }
            return buecher;
        }
    }
}