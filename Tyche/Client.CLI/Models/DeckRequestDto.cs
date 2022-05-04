using System.Text.Json.Serialization;


namespace Client.CLI.Models
{
    public class DeckRequestDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("deckType")]
        public DeckType DeckType { get; set; }
    }
}
