namespace CinemaProject.Models
{
    public class BigliettoViewModel : SpettatoreViewModel
    {
        public int IdBiglietto { get; set; }
        public int NSala { get; set; }
        public int NPosto { get; set; }
        public decimal Costo { get; set; }
    }
}
