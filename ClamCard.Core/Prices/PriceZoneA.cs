using ClamCard.Core.Models;

namespace ClamCard.Core.Prices
{
    public class PriceZoneA : IPrice
    {

        public Zone Zone()
        {
            return Models.Zone.A;
        }
        public double Day()
        {
            return 7;
        }

        public double Month()
        {
            return 145;
        }

        public double Single()
        {
            return 2.50;
        }

        public double Week()
        {
            return 40;
        }

    }
}
