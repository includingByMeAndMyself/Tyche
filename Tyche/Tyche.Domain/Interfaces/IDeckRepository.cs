
using System.Threading.Tasks;
using Tyche.Domain.Models;

namespace Tyche.Domain.Interfaces
{
    public interface IDeckRepository
    {
        Task<bool> AddAsync(Deck deck, string name);

        Task<Deck> GetDeckAsync(string name);
        
        Task<bool> DeleteAsync(string name);

        Task<Deck[]>  GetDecksAsync();

        Task<string[]>  GetDecksNamesAsync();

        Task<bool> DeleteDecksAsync();
    }
}
