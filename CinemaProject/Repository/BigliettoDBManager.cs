using CinemaProject.Models;
using System.Data.SqlClient;

namespace CinemaProject.Repository
{
    public class BigliettoDBManager
    {
        string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = Cinema; Trusted_Connection = true";


        public List<BigliettoViewModel> GetAllBiglietti()
        {
            string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = Cinema; Trusted_Connection = true";
            List<BigliettoViewModel> bigliettoList = new List<BigliettoViewModel>();
            string sql = @"Select * from Biglietto";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            BigliettoViewModel biglietto;
            while (reader.Read())
            {
                biglietto = new BigliettoViewModel()
                {
                    IdSpettatore = Convert.ToInt32(reader["IdSpettatore"].ToString()),
                    IdBiglietto = Convert.ToInt32(reader["IdBiglietto"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    DataNascita = DateTime.Parse(reader["DataNascita"].ToString()),
                    NSala = Convert.ToInt32(reader["NSala"].ToString()),
                    NPosto = Convert.ToInt32(reader["NPosto"].ToString()),
                    Costo = Decimal.Parse(reader["Durata"].ToString())
                };
                bigliettoList.Add(biglietto);
            }

            return bigliettoList;
        }

        public int AddBiglietto(BigliettoViewModel biglietto)
        {
            string sql = @"INSERT INTO [dbo].[Biglietto]
                                ([NSala],[NPosto],[Costo])
                                values (@NSala, @NPosto, @Costo)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NSala", biglietto.NSala);
            command.Parameters.AddWithValue("@NPosto", biglietto.NPosto);
            command.Parameters.AddWithValue("@Costo", biglietto.Costo);
            return command.ExecuteNonQuery();
        }

        public int DetailsBiglietto(BigliettoViewModel biglietto)
        {
            string sql = @"SELECT * FROM dbo.Biglietto B
                            JOIN Spettatore S ON B.IdSpettatore = S.IdSpettatore";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSpettatore", biglietto.IdSpettatore);
            command.Parameters.AddWithValue("@IdBiglietto", biglietto.IdBiglietto);
            command.Parameters.AddWithValue("@Nome", biglietto.Nome);
            command.Parameters.AddWithValue("@Cognome", biglietto.Cognome);
            command.Parameters.AddWithValue("@DataNascita", biglietto.DataNascita);
            command.Parameters.AddWithValue("@NSala", biglietto.NSala);
            command.Parameters.AddWithValue("@NPosto", biglietto.NPosto);
            command.Parameters.AddWithValue("@Costo", biglietto.Costo);
            return command.ExecuteNonQuery();
        }


    }
}
