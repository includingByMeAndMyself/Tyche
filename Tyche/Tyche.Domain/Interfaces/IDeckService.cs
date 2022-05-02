using Tyche.Domain.Models;


namespace Tyche.Domain.Interfaces
{
    public interface IDeckService
    {
        Deck GetNamedDeck(int suit);

        string CreateNamedDeck(Suit suit);
    }
}
