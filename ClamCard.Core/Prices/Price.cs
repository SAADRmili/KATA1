using ClamCard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClamCard.Core.Prices
{
    public class Price : IPrice
    {
        public double Day(Zone zone)
        {
            if (zone == Zone.A) return 7;
            return 8;
        }

        public double Month(Zone zone)
        {
            if (zone == Zone.A) return 145;
            return 165;
        }

        public double Single(Zone zone)
        {
            if (zone == Zone.A) return 2.5;
            return 3;
        }

        public double Week(Zone zone)
        {
            if (zone == Zone.A) return 40;
            return 47;
        }
    }
}
