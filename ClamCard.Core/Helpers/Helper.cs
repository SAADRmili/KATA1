using ClamCard.Core.Models;
using ClamCard.Core.Prices;
using System.Collections.Immutable;

namespace ClamCard.Core.Helpers
{
    public class Helper
    {
        private readonly IPrice _price;

        public Helper()
        {
            _price = new Price(); 
        }

        public  double CostPerSingleJourney(Station from , Station to)
        {
            var startCost = _price.Single(from.Zone);

            var toCost = _price.Single(to.Zone);

            return Math.Max(startCost, toCost); 
            
        }

        public double CostPerDayLimit(Station from, Station to)
        {
            var startCost = _price.Day(from.Zone);

            var toCost = _price.Day(to.Zone);

            return Math.Max(startCost, toCost);
        }

        public double CostPerWeekLimit(Station from, Station to)
        {
            var startCost = _price.Week(from.Zone);

            var toCost = _price.Week(to.Zone);

            return Math.Max(startCost, toCost);
        }

        public double CostPerMonthLimit(Station from, Station to)
        {
            var startCost = _price.Month(from.Zone);

            var toCost = _price.Month(to.Zone);

            return Math.Max(startCost, toCost);
        }
    }
}
