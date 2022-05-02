
namespace Tyche.DataAccess.MsSql.Entities
{
    public class CardEntity
    {
        public int Id { get; set; }

        public string Rank { get; set; }

        public string Suit { get; set; }

        public int DeckId { get; set; }

        public DeckEntity Deck { get; set; } 
    }
}
