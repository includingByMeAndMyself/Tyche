using Tyche.Domain.Models;


namespace Tyche.Domain.Interfaces
{
    public interface IDeckService
    {
        public string CreateNamedDeck(Suit suit);

        public Deck GetDeckBySuit(Suit suit);

        public Deck[] GetDecks();

        public string[] GetCreatedDecksSuits();

        public string DeleteDeckBySuit(Suit suit);

        public string ShuffleDeckBySuit(Suit suit, int sortOption);
    }
}
