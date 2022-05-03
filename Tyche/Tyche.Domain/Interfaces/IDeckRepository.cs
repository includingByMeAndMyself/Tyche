
using Tyche.Domain.Models;

namespace Tyche.Domain.Interfaces
{
    public interface IDeckRepository
    {
        void Add(Deck deck, string name);

        void Delete(string name);

        Deck GetDeck(string name);

        Deck[] GetDecks();

        string[] GetDecksNames();
        
        void DeleteDecks();
    }
}
