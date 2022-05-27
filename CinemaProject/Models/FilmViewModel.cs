namespace CinemaProject.Models
{
    public class FilmViewModel
    {
        public int IdFilm { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Produttore { get; set; }
        public string Genere { get; set; }
        public decimal Durata { get; set; }
    }
}
