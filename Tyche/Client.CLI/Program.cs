using System;
using System.Net.Http;

namespace Client.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var baseUri = new Uri("https://localhost:5001");
            var deckHttpClient = new DeckHttpClient(httpClient, baseUri);

            var application = new Client(deckHttpClient);
            application.Start();
        }
    }
}
