using ClamCard.Core.Models;
using ClamCard.Core.Services;
using Xunit;
using System.Linq;

namespace ClamCard.Test
{
    public class ClamCardTests
    {

        private readonly Card _card = new Card();
        private readonly ClamCardService _cardService;

        public ClamCardTests()
        {
            _cardService = new ClamCardService(_card);
        }

        //One-Way Zone 1 Journey
        [Fact]
        public void TestClamCardServiceCalculateCostOneWay()
        {
            var stationFrom = new Station
            {
                Name = "Asterisk ",
                Zone = Zone.A
            };

            var stationTo = new Station
            {
                Name = "Aldgate  ",
                Zone = Zone.A
            };

            _cardService.StartJournery(stationFrom);
           var journey =  _cardService.EndJournery(stationTo);


            Assert.NotNull(_card.Journeys);
            Assert.True(journey.Cost == 2.5);
           
        }


        //One-Way Zone 1 to Zone 2 Journey

        [Fact]
        public void TestClamCardServiceCalculateCostOneWayBetweenZones()
        {
            var stationFrom = new Station
            {
                Name = "Asterisk ",
                Zone = Zone.A
            };

            var stationTo = new Station
            {
                Name = "Barbican",
                Zone = Zone.B
            };

            _cardService.StartJournery(stationFrom);
            var journey = _cardService.EndJournery(stationTo);


            Assert.NotNull(_card.Journeys);
            Assert.True(journey.Cost == 3);

        }

        //Multiple journeys

        [Fact]
        public void TestClamCardServiceCalculateCostMultiplJourneys()
        {
            var stationFrom = new Station
            {
                Name = "Asterisk ",
                Zone = Zone.A
            };

            var stationTo = new Station
            {
                Name = "Aldgate",
                Zone = Zone.A
            };

            _cardService.StartJournery(stationFrom);
            var journey = _cardService.EndJournery(stationTo);

            _cardService.HistoryJourney(journey);
             stationFrom = new Station
            {
                Name = "Asterisk ",
                Zone = Zone.A
            };

             stationTo = new Station
            {
                Name = "Balham",
                Zone = Zone.B
            };

            _cardService.StartJournery(stationFrom);
             journey = _cardService.EndJournery(stationTo);
            _cardService.HistoryJourney(journey);



            Assert.NotNull(_card.Journeys);
            Assert.Equal(journey.Cost, 3);

          

        }
    }
}