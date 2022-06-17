
namespace ClamCard.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Card Card { get; set; }
    }
}
