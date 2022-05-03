
namespace Tyche.Domain.Models
{
    public class Card
    {
        public int SequenceNumber { get; }

        public Rank Rank { get; }

        public Suit Suit { get; }

        public Card(Rank rank, Suit suit, int sequenceNumber)
        {
            Rank = rank;
            Suit = suit;
            SequenceNumber = sequenceNumber;
        }
    }
}
