using Client.CLI.Interfaces;
using Client.CLI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Client.CLI
{
    public class DeckHttpClient : IDeckHttpClient
    {
        private readonly HttpClient _client;

        public DeckHttpClient(HttpClient client, Uri baseUri)
        {
            _client = client;
            _client.BaseAddress = baseUri;
        }

        public Task<string> CreateNamedDeckAsync(string name, DeckType deckType)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDeckByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDecksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string[]> GetCreatedDecksNamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Deck> GetDeckByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Deck[]> GetDecksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> ShuffleDeckByNameAsync(int sortOption, string name)
        {
            throw new NotImplementedException();
        }
    }
}
