namespace CinemaProject.Models
{
    public class SpettatoreViewModel
    {
        public int IdSpettatore { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly DataNascita { get; set; }
    }
}
