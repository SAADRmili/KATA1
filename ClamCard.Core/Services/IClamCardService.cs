using ClamCard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClamCard.Core.Services
{
    public interface IClamCardService
    {

        void HistoryJourney(Journey Fulljourney);

        double CalculateCostJourney(Station station,DateTime date);


        void StartJournery(Station station);

        Journey EndJournery (Station station);
    }
}
