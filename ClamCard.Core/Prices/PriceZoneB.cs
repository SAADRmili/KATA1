using ClamCard.Core.Models;

namespace ClamCard.Core.Prices
{
    public class PriceZoneB : IPrice
    {
        public Zone Zone()
        {
            return Models.Zone.B;
        }
        public double Day()
        {
            return 8;
        }

        public double Month()
        {
            return 165;
        }

        public double Single()
        {
            return 3;
        }

        public double Week()
        {
            return 47;
        }
    }
}
