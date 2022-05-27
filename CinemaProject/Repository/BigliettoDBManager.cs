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

        //public int AddSpettatore(SpettatoreViewModel spettatore)
        //{
        //    string sql = @"INSERT INTO [dbo].[Spettatore]
        //                        ([Nome],[Cognome],[DataNascita])
        //                        values (@Nome, @Cognome, @DataNascita)";
        //    using var connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    using var command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@Nome", spettatore.Nome);
        //    command.Parameters.AddWithValue("@Cognome", spettatore.Cognome);
        //    command.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);
        //    return command.ExecuteNonQuery();
        //}


    }
}
