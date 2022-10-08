using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace BuchDatenbank
{
    public class BuchRepository
    {
        private string _connectionString;

        public BuchRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }


        public List<BuchDTO> HoleAlleBuecher()
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "SELECT id, buecher_title, buecher_author FROM buecher";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            var reader = kommando.ExecuteReader();

            List<BuchDTO> buecher = new();
            while (reader.Read())
            {
                var buch = new BuchDTO();
                BuchDTO.Id = reader.GetInt32(0);
                BuchDTO.title = reader.GetString(1);
                BuchDTO.author = reader.GetString(2);
               
                buecher.Add(buch);
            }
            return buecher;
        }

        public void FuegeBuchEin(string buchTitel, string buchAutor, string buchTyp)
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "INSERT INTO buecher (buecher_title, buecher_author, buecher_type)"
                + "VALUES (@buecher_title, @buecher_author, @buecher_type);";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            kommando.Parameters.AddWithValue("@buecher_title", buchTitel);
            kommando.Parameters.AddWithValue("@buecher_author", buchAutor);
            kommando.Parameters.AddWithValue("@buecher_type", buchTyp);
            kommando.ExecuteNonQuery();

        }


    }

}
