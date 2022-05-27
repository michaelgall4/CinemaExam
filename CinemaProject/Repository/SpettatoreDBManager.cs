using CinemaProject.Models;
using System.Data.SqlClient;

namespace CinemaProject.Repository
{
    public class SpettatoreDBManager
    {
        string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = Cinema; Trusted_Connection = true";


        public List<SpettatoreViewModel> GetAllSpettatori()
        {
            string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = Cinema; Trusted_Connection = true";
            List<SpettatoreViewModel> spettatoreList = new List<SpettatoreViewModel>();
            string sql = @"Select * from Spettatore";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            SpettatoreViewModel spettatore;
            while (reader.Read())
            {
                spettatore = new SpettatoreViewModel()
                {
                    IdSpettatore = Convert.ToInt32(reader["IdSpettatore"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    DataNascita = DateTime.Parse(reader["DataNascita"].ToString())
                };
                spettatoreList.Add(spettatore);
            }

            return spettatoreList;
        }

        public int AddSpettatore(SpettatoreViewModel spettatore)
        {
            string sql = @"INSERT INTO [dbo].[Spettatore]
                                ([Nome],[Cognome],[DataNascita])
                                values (@Nome, @Cognome, @DataNascita)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", spettatore.Nome);
            command.Parameters.AddWithValue("@Cognome", spettatore.Cognome);
            command.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);
            return command.ExecuteNonQuery();
        }


    }
}
