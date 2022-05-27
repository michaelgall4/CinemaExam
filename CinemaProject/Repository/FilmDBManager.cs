using CinemaProject.Models;
using System.Data.SqlClient;

namespace CinemaProject.Repository
{
    public class FilmDBManager
    {
        string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = Cinema; Trusted_Connection = true";


        public List<FilmViewModel> GetAllFilm()
        {
            string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = Cinema; Trusted_Connection = true";
            List<FilmViewModel> filmList = new List<FilmViewModel>();
            string sql = @"Select * from Film";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            FilmViewModel film;
            while (reader.Read())
            {
                film = new FilmViewModel()
                {
                    IdFilm = Convert.ToInt32(reader["IdFilm"].ToString()),
                    Titolo = reader["Titolo"].ToString(),
                    Autore = reader["Autore"].ToString(),
                    Produttore = reader["Produttore"].ToString(),
                    Genere = reader["Genere"].ToString(),
                    Durata = Decimal.Parse(reader["Durata"].ToString())
                };
                filmList.Add(film);
            }

            return filmList;
        }

        public int DetailsFilm(FilmViewModel film)
        {
            string sql = @"SELECT [IdFilm],
                                  [Titolo],
                                  [Autore],
                                  [Produttore],
                                  [Genere],
                                  [Durata]
                              FROM [dbo].[Film]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdFilm", film.IdFilm);
            command.Parameters.AddWithValue("@Titolo", film.Titolo);
            command.Parameters.AddWithValue("@Autore", film.Autore);
            command.Parameters.AddWithValue("@Produttore", film.Produttore);
            command.Parameters.AddWithValue("@Genere", film.Genere);
            command.Parameters.AddWithValue("@Durata", film.Durata);
            return command.ExecuteNonQuery();
        }


    }
}

