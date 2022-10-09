using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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


        // Importiert alle Bücher aus beiden Tabellen der Datenbank und fügt sie in eine gemeinsam Liste ein
        // Dies ist auch der Grund, dass die IDs der ursprünglich vorhandenen Bücher korrekt zugeordnet sind
        // über das Formular eingefügte Bücher aber gemeinsam in der ID incrementiert werden
        public List<BuchDTO> HoleAktuelleBuecher()
        {
                     
                using var datenbankVerbindung = new MySqlConnection(_connectionString);
                using var datenbankVerbindung2 = new MySqlConnection(_connectionString);
                datenbankVerbindung.Open();
                datenbankVerbindung2.Open();

                const string query = "SELECT * FROM archivierte_buecher;";
                const string query2 = "SELECT * FROM aktuelle_buecher;";
                using var kommando = new MySqlCommand(query, datenbankVerbindung);
                using var kommando2 = new MySqlCommand(query2, datenbankVerbindung2);
                var reader = kommando.ExecuteReader();
                var reader2 = kommando2.ExecuteReader();

                List<BuchDTO> buchliste = new();
                while (reader.Read())
                {                
                        var buch = new BuchDTO();
                        buch.Id = reader.GetInt32(0);
                        buch.title = reader.GetString(1);
                        buch.author = reader.GetString(2);
                        buch.type = reader.GetString(3);
                        
                        buchliste.Add(buch);
                
                }
                while (reader2.Read())
                {
                    var buch = new BuchDTO();
                    buch.Id = reader2.GetInt32(0);
                    buch.title = reader2.GetString(1);
                    buch.author = reader2.GetString(2);
                    buch.type = reader2.GetString(3);

                    buchliste.Add(buch);
                }
                return buchliste;
                
           
        }

        // Funktion für das Einfügen eines neuen "Aktuellen" Buches in die MariaDB
        public void FuegeBuchEin(string buchTitel, string buchAutor, string buchType)
        {
            
                using var datenbankVerbindung = new MySqlConnection(_connectionString);
                datenbankVerbindung.Open();
            
                    const string query = "INSERT INTO aktuelle_buecher (buecher_title, buecher_author, buecher_type)"
                        + "VALUES (@buecher_title, @buecher_author, @buecher_type);";
                    using var kommando = new MySqlCommand(query, datenbankVerbindung);
                    kommando.Parameters.AddWithValue("@buecher_title", buchTitel);
                    kommando.Parameters.AddWithValue("@buecher_author", buchAutor);
                    kommando.Parameters.AddWithValue("@buecher_type", buchType);
                   
                    kommando.ExecuteNonQuery();
            

        }


        // Funktion für das Einfügen eines neuen "Archivierten" Buches in die MariaDB
        public void FuegeBuchEin2(string buchTitle, string buchAutor, string buchType)
        {
            
                using var datenbankVerbindung = new MySqlConnection(_connectionString);
                datenbankVerbindung.Open();

                const string query = "INSERT INTO archivierte_buecher (buecher_title, buecher_author, buecher_type)"
                    + "VALUES (@buecher_title, @buecher_author, @buecher_type);";
                using var kommando = new MySqlCommand(query, datenbankVerbindung);
                kommando.Parameters.AddWithValue("@buecher_title", buchTitle);
                kommando.Parameters.AddWithValue("@buecher_author", buchAutor);
                kommando.Parameters.AddWithValue("@buecher_type", buchType);

                kommando.ExecuteNonQuery();
           
        }

    }

}
