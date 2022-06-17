using ClamCard.Core.Helpers;
using ClamCard.Core.Models;

namespace ClamCard.Core.Services
{
    public class ClamCardService : IClamCardService
    {
        private readonly Card card;
        private readonly Helper _helpers;

        private Station CurrentJourneyStart { get; set; }

        public ClamCardService(Card card)

        {
            _helpers = new Helper();
            this.card = card;
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
            card.Journeys.Add(Fulljourney);
        }



        public double CalculateCostJourney(Station station,DateTime date)
        {
            var cost = _helpers.CostPerSingleJourney(CurrentJourneyStart, station);

            //calculate costs per time 
            var costDay = _helpers.CostPerDayLimit(CurrentJourneyStart,station) ;
            var costWeek = _helpers.CostPerDayLimit(CurrentJourneyStart,station) ;
            var costMonth = _helpers.CostPerDayLimit(CurrentJourneyStart,station) ;

            //cacluclate History cost journy by time
            var sumCostByDay = card.Journeys.Where(j => j.Date == date.Date).Sum(j => j.Cost);
            var sumCostByMonth = card.Journeys.Where(j => j.Date.Year == date.Date.Year && j.Date.Month == date.Month).Sum(j => j.Cost);

            cost = (sumCostByDay + cost > costDay) ? costDay - sumCostByDay : cost;
            cost = (sumCostByMonth + cost > costDay) ? costDay - sumCostByMonth : cost;

            return cost;
        }


    }
}
