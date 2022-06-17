namespace ClamCard.Core.Models
{
    public class Journey
    {
        public Station From { get; set; }
        public Station To { get; set; }

        public DateTime Date { get; set; }
        public double Cost { get; set; }

        
    }
}
