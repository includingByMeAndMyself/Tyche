using Client.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Client.CLI.Infrastructure
{
    public static class Automapper
    {
        public static Deck MappingToDeck(DeckResponse deckResponse)
        {
            var cardsResponse = deckResponse.Cards.ToList();
            var cards = new List<Card>();

            foreach (var cardResponse in cardsResponse)
            {
                var splitResult = cardResponse.Split(';');

                var sequenceNumber = int.Parse(splitResult[0]);
                var rank = (Rank)Enum.Parse(typeof(Rank), splitResult[1]);
                var suit = (Suit)Enum.Parse(typeof(Suit), splitResult[2]);

                cards.Add(new Card(rank, suit, sequenceNumber));
            }

            var name = deckResponse.Name;

            return new Deck(cards.ToArray(), name);
        }
    }
}
