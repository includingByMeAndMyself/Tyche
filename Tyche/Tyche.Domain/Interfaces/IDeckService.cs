using Tyche.Domain.Models;


namespace Tyche.Domain.Interfaces
{
    public interface IDeckService
    {
        string CreateNamedDeck(string name, DeckType deckType);

        Deck GetDeckByName(string name);

        Deck[] GetDecks();

        string[] GetCreatedDecksNames();

        string DeleteDeckByName(string name);

        string ShuffleDeckBySuit(int sortOption);

        string DeleteDecks();
    }
}
