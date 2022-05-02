
using Tyche.Domain.Models;

namespace Tyche.Domain.Interfaces
{
    public interface IDeckRepository
    {
        void Add(Deck deck);

        void Update(Deck deck);

        void Delete(Suit suit);

        Deck GetDeck(Suit suit);

        Deck[] Get();

        string[] GetDecksSuit();
    }
}
