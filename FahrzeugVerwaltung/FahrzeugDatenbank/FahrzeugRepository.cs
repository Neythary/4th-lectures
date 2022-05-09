using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace FahrzeugDatenbank
{
    public class FahrzeugRepository
    {
        private string _connectionString;

        public void FuegeFahrzeugEin(string fahrzeugName, string fahrzeugTyp) {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "INSERT INTO fahrzeuge (fahrzeug_name, fahrzeug_typ)" 
                + "VALUES (@fahrzeug_name, @fahrzeug_typ);";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            kommando.Parameters.AddWithValue("@fahrzeug_name", fahrzeugName);
            kommando.Parameters.AddWithValue("@fahrzeug_typ", fahrzeugTyp);
            kommando.ExecuteNonQuery();

        }


        public void LoescheFahrzeug(int id)
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "DELETE FROM fahrzeuge WHERE id = @id;";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            kommando.Parameters.AddWithValue("@id", id);
            kommando.ExecuteNonQuery();

        }

        public void Suche (string? eingabe)
        {
        

        }


        public FahrzeugRepository(string connecitonString)
        {
            this._connectionString = connecitonString;
        }

        public List<FahrzeugDTO> HoleAlleFahrzeuge()
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "SELECT id, fahrzeug_name, fahrzeug_typ FROM fahrzeuge";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            var reader = kommando.ExecuteReader();

            List<FahrzeugDTO> fahrzeuge = new();
            while (reader.Read())
            {
                var fahrzeug = new FahrzeugDTO();
                fahrzeug.Id = reader.GetInt32(0);
                fahrzeug.Name = reader.GetString(1);
                fahrzeug.Typ = reader.GetString(2);

                fahrzeuge.Add(fahrzeug);
            }

            return fahrzeuge;
        }
    }
}
