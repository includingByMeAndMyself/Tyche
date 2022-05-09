using System;
using System.Collections.Generic;
using System.Linq;
using Tyche.Domain.Models;


namespace Tyche.BusinessLogic.Infrasturcure
{
    internal class CardShuffler
    {
        protected static Random _random = new Random();

        public Deck SimpleShuffle(Deck deck)
        {
            var sequenceNumbersRandom = Enumerable.Range(1, deck.Count + 1)
                                            .OrderBy(n => _random.Next(1, deck.Count + 1))
                                            .ToArray();

            List<Card> cards = new List<Card>();
            var count = 0;
            foreach (var card in deck.Cards)
            {
                cards.Add(new Card(card.Rank, card.Suit, sequenceNumbersRandom[count]));
                count++;
            }

            return new Deck(cards.ToArray(), deck.Name);
        }
    }
}
