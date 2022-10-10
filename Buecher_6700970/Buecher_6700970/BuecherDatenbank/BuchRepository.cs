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
        public List<BuchDTO> HoleAktuelleBuecher()
        {

            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();
            
            const string query = "SELECT * FROM aktuelle_buecher;";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            var reader = kommando.ExecuteReader();
            

            List<BuchDTO> buchliste = new();
            while (reader.Read())
            {
                var buch = new BuchDTO();
                buch.title = reader.GetString(0);
                buch.author = reader.GetString(1);

                buchliste.Add(buch);

            }
            return buchliste;
        }

        public List<BuchDTO> HoleArchivierteBuecher()
        {
            using var datenbankVerbindung2 = new MySqlConnection(_connectionString);
            datenbankVerbindung2.Open();

            const string query2 = "SELECT * FROM archivierte_buecher;";
            using var kommando2 = new MySqlCommand(query2, datenbankVerbindung2);
            var reader2 = kommando2.ExecuteReader();

            List<BuchDTO> buchliste = new();
            while (reader2.Read())
            {
                var buch = new BuchDTO();
                buch.title = reader2.GetString(0);
                buch.author = reader2.GetString(1);

                buchliste.Add(buch);
            }
            return buchliste;
        }

        public void Verschieben(BuchDTO buch, string quelle, string ziel)
        {
            using var db_Verbindung = new MySqlConnection(_connectionString);

            Loeschen(buch, quelle); //Lösche das Buch aus der Quelltabelle

            FuegeBuchEin(buch, ziel); //Füge das buch der Zieltabelle hinzu
        }

        public void Loeschen(BuchDTO buch, string quelle)
        {
            //Datenbankverbindung aufbauen und Befehl zum Löschen aus der Quelladresse wird hier ausgeführt
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            string Loeschen = "DELETE FROM " + quelle + " WHERE buecher_title = @buecher_title AND buecher_author = @buecher_author";
            using var command = new MySqlCommand(Loeschen, datenbankVerbindung);
            command.Parameters.AddWithValue("buecher_title", buch.title);
            command.Parameters.AddWithValue("buecher_author", buch.author);

            command.ExecuteNonQuery();

            datenbankVerbindung.Close();
        }

        public void FuegeBuchEin(BuchDTO buch, string ziel)
        {
            //Datenbankverbindung aufbauen und Befehl zum Einfuegen in die Zieladresse wird hier ausgeführt
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            string loeschen = "INSERT INTO " + ziel + " (buecher_title, buecher_author) VALUES ('" + buch.title + "', '" + buch.author + "')";
            using var command = new MySqlCommand(loeschen, datenbankVerbindung);
            command.Parameters.AddWithValue("buecher_title", buch.title);
            command.Parameters.AddWithValue("buecher_author", buch.author);

            command.ExecuteNonQuery();

            datenbankVerbindung.Close();
        }



        /*
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

        public void VerschiebenBuch(string buchTitel, string buchAutor, string buchTyp)
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            using var datenbankVerbindung2 = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();
            datenbankVerbindung2.Open();

            if (buchTyp == "aktiv")
            {
                const string query = "INSERT INTO aktuelle_buecher (buecher_title, buecher_author, buecher_type)"
                        + "VALUES (@buecher_title, @buecher_author, @buecher_type);";
                using var kommando = new MySqlCommand(query, datenbankVerbindung);
                kommando.Parameters.AddWithValue("@buecher_title", buchTitel);
                kommando.Parameters.AddWithValue("@buecher_author", buchAutor);
                kommando.Parameters.AddWithValue("@buecher_type", buchTyp);
                kommando.ExecuteNonQuery();

                const string query2 = "DELETE FROM archivierte_buecher WHERE title = @title;";
                using var kommando2 = new MySqlCommand(query2, datenbankVerbindung2);
                kommando2.Parameters.AddWithValue("@title", buchTitel);
                kommando2.ExecuteNonQuery();

            }
            else if (buchTyp == "archiv")
            {
                const string query = "INSERT INTO archivierte_buecher (buecher_title, buecher_author, buecher_type)"
                        + "VALUES (@buecher_title, @buecher_author, @buecher_type);";
                using var kommando = new MySqlCommand(query, datenbankVerbindung);
                kommando.Parameters.AddWithValue("@buecher_title", buchTitel);
                kommando.Parameters.AddWithValue("@buecher_author", buchAutor);
                kommando.Parameters.AddWithValue("@buecher_type", buchTyp);
                kommando.ExecuteNonQuery();

                const string query2 = "DELETE FROM aktuelle_buecher WHERE title = @title;";
                using var kommando2 = new MySqlCommand(query2, datenbankVerbindung2);
                kommando2.Parameters.AddWithValue("@title", buchTitel);
                kommando2.ExecuteNonQuery();
            }

        }*/

    }
}
