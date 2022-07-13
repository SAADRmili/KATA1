using ClamCard.Core.Helpers;
using ClamCard.Core.Models;

namespace ClamCard.Core.Services
{
    public class ClamCardService : IClamCardService
    {
        private readonly Card Card;
        private readonly Helper _helpers;

        private Station CurrentJourneyStart { get; set; }

        public ClamCardService(Card card)

        {
            _helpers = new Helper();
            this.Card = card;
        }

        public void StartJournery(Station station)
        {
            CurrentJourneyStart = station;
        }

        public Journey EndJournery(Station station)
        {
            if (CurrentJourneyStart == station) return null;

            var journey = new Journey
            {
                From = CurrentJourneyStart,
                To = station,
                Cost = CalculateCostJourney(station,DateTime.Now),
            };

            return journey;
        }


        public void HistoryJourney(Journey Fulljourney)
        {
            CurrentJourneyStart = null;
            Card.Journeys.Add(Fulljourney);
        }



        public double CalculateCostJourney(Station station,DateTime date)
        {
            var cost = _helpers.CostPerSingleJourney(CurrentJourneyStart, station);
            //calculate costs per time 
            var costDay = _helpers.CostPerDayLimit(CurrentJourneyStart,station) ;
            //cacluclate History cost journy by time
            var sumCostByDay = Card.Journeys.Where(j => j.Date == date.Date).Sum(j => j.Cost);

            cost = (sumCostByDay + cost > costDay) ? costDay - sumCostByDay : cost;
        
            return cost;
        }


    }
}
