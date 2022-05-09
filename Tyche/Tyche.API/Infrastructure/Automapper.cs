using System.Collections.Generic;
using Tyche.API.Models;
using Tyche.Domain.Models;

namespace Tyche.API.Infrastructure
{
    internal class Automapper
    {
        public DeckResponse MappingToDeckResponse(Deck deck)
        {
            var cards = deck.Cards;
            var cardsResponse = new List<string>();

            foreach (var card in cards)
            {
                var cardResponse = $"{card.SequenceNumber};{card.Rank.ToString()};{card.Suit.ToString()}";
                cardsResponse.Add(cardResponse);
            }

            return new DeckResponse
            {
                Cards = cardsResponse.ToArray(),
                Name = deck.Name
            };
        }
    }
}
