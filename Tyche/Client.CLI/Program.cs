using System;
using System.Net.Http;

namespace Client.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var baseCafeUri = new Uri("http://localhost:5000");
            var cafeHttpClient = new DeckHttpClient(httpClient, baseCafeUri);

            var application = new Client(cafeHttpClient);
            application.Start();
        }
    }
}
