using Client.CLI.Infrastructure;
using Client.CLI.Interfaces;
using Client.CLI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public async Task<string> DeleteDeckByNameAsync(string name)
        {
            var url = _client.BaseAddress.ToString() + $"Deck/DeckByName/{name}";

            try
            {
                var response = await _client.DeleteAsync(url);

                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteDecksAsync()
        {
            var url = _client.BaseAddress.ToString() + $"Deck/Decks";

            try
            {
                var response = await _client.DeleteAsync(url);

                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string[]> GetCreatedDecksNamesAsync()
        {
            var url = _client.BaseAddress.ToString() + "Deck/Names";

            try
            {
                var response = _client.GetAsync(url).Result;
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<string[]>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Deck> GetDeckByNameAsync(string name)
        {
            var url = _client.BaseAddress.ToString() + $"Deck/DeckByName/{name}";
            try
            {
                var response = _client.GetAsync(url).Result;
                var json = await response.Content.ReadAsStringAsync();

                var deckResponse = JsonConvert.DeserializeObject<DeckResponse>(json);

                if(deckResponse != null)
                {
                    var deck = Automapper.MappingToDeck(deckResponse);
                    return deck;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Deck[]> GetDecksAsync()
        {
            var url = _client.BaseAddress.ToString() + $"Deck/Decks";
            try
            {
                var response = _client.GetAsync(url).Result;
                var json = await response.Content.ReadAsStringAsync();

                var decksResponse = JsonConvert.DeserializeObject<DeckResponse[]>(json);

                if (decksResponse != null)
                {
                    var decks = new List<Deck>();
                    foreach (var deckResponse in decksResponse)
                    {
                        var deck = Automapper.MappingToDeck(deckResponse);
                        decks.Add(deck);
                    }
                    return decks.ToArray();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> ShuffleDeckByNameAsync(ShuffleOption shuffleOption, string name)
        {
            var request = new ShuffleRequest
            {
                Name = name,
                ShuffleOption = (int)shuffleOption
            };

            var url = _client.BaseAddress.ToString() + "Deck/Shuffle";

            var data = JsonConvert.SerializeObject(request);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PutAsync(url, content);

                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
