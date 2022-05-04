using Client.CLI.Interfaces;
using Client.CLI.Models;
using Microsoft.AspNet.SignalR.Client.Infrastructure;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public async Task<string> CreateNamedDeckAsync(string name, DeckType deckType)
        {
            var request = new DeckRequestDto
            {
                Name = name,
                DeckType = deckType
            };

            var url = _client.BaseAddress.ToString() + "Deck";

            var data = JsonConvert.SerializeObject(request);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(url, content);

                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
