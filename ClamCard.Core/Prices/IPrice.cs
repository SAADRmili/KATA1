using ClamCard.Core.Models;

namespace ClamCard.Core.Prices
{
    public interface IPrice
    {
        double Single(Zone zone );
        double Day(Zone zone);
        double Week(Zone zone);
        double Month(Zone zone);
    }
}
