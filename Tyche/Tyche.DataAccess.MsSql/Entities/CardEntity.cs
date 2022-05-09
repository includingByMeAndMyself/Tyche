Ы
using System.ComponentModel.DataAnnotations;

namespace Tyche.DataAccess.MsSql.Entities
{
    public class CardEntity
    {
        public int Id { get; set; }

        public int SequenceNumber { get; set; }

        [StringLength(20)]
        public string Rank { get; set; }

        [StringLength(20)]
        public string Suit { get; set; }

        public int DeckId { get; set; }

        public DeckEntity Deck { get; set; } 
    }
}
