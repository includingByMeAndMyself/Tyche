using System.Threading.Tasks;
using Tyche.Domain.Models;


namespace Tyche.Domain.Interfaces
{
    public interface IDeckService
    {
        Task<string> CreateNamedDeckAsync(string name, DeckType deckType);

        Task<Deck> GetDeckByNameAsync(string name);

        Task<Deck[]> GetDecksAsync();

        Task<string[]> GetCreatedDecksNamesAsync();

        Task<string> DeleteDeckByNameAsync(string name);

        Task<string> ShuffleDeckByNameAsync(int sortOption, string name);

        Task<string> DeleteDecksAsync();
    }
}
