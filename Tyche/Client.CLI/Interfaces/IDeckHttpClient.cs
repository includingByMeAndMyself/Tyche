using Client.CLI.Models;
using System.Threading.Tasks;


namespace Client.CLI.Interfaces
{
    public interface IDeckHttpClient
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
