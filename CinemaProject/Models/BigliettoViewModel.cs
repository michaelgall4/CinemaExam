namespace CinemaProject.Models
{
    public class BigliettoViewModel : SpettatoreViewModel
    {
        public string IdBiglietto { get; set; }
        public int Nsala { get; set; }
        public int NPosto { get; set; }
        public decimal Costo { get; set; }
    }
}
