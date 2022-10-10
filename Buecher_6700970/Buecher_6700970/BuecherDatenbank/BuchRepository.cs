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


        // Importiert die aktuellen Bücher aus beiden Tabellen der Datenbank und fügt sie in eine Liste ein
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
                buch.title = reader.GetString(1);
                buch.author = reader.GetString(2);

                buchliste.Add(buch);

            }
            return buchliste;
        }

        // Importiert die archivierten Bücher aus beiden Tabellen der Datenbank und fügt sie in eine Liste ein
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
                buch.title = reader2.GetString(1);
                buch.author = reader2.GetString(2);

                buchliste.Add(buch);
            }
            return buchliste;
        }

        // über den BuchController angsprochene Funktion zum Verschieben von Büchern
        // zunächst muss das Buch in der ursprungstabelle gelöscht werden
        // zusätzlich muss das Buch in der neuen Tabelle neu angelegt werden
        public void Verschieben(BuchDTO buch, string quelle, string ziel)
        {
            using var db_Verbindung = new MySqlConnection(_connectionString);

            Loeschen(buch, quelle); 

            FuegeBuchEin(buch, ziel); 
        }

        // Funktion zum Löschen eines Buches aus seiner Ursprungstabelle
        public void Loeschen(BuchDTO buch, string quelle)
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            string Loeschen = "DELETE FROM " + quelle + " WHERE titel = @titel AND autor = @autor";
            using var command = new MySqlCommand(Loeschen, datenbankVerbindung);
            command.Parameters.AddWithValue("titel", buch.title);
            command.Parameters.AddWithValue("autor", buch.author);

            command.ExecuteNonQuery();

            datenbankVerbindung.Close();
        }

        // Funktion zum Einfügen eines Buches in seine neue Tabelle
        public void FuegeBuchEin(BuchDTO buch, string ziel)
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            string loeschen = "INSERT INTO " + ziel + " (titel, autor) VALUES ('" + buch.title + "', '" + buch.author + "')";
            using var command = new MySqlCommand(loeschen, datenbankVerbindung);
            command.Parameters.AddWithValue("titel", buch.title);
            command.Parameters.AddWithValue("autor", buch.author);

            command.ExecuteNonQuery();

            datenbankVerbindung.Close();
        }

        // Beim erneuten Versuch die DI umzusetzen kam es zu einem neuartigen Fehler, der nicht auf Fehler in 
        // der Implementierung der DI hinweist
        // Daraufhin wurde alles nochmal umgearbeitet, auch im hinblick auf die Aufgabenstellung Threads für 
        // die Daten einbindung zu verwenden

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
