using System;
using System.Collections.Generic;


namespace Tyche.Domain.Models
{
    public class Deck
    {
        private Stack<Card> _cards;

        public Stack<Card> Cards { get { return _cards; } }

        public int Count { get; private set; }

        public Suit Suit { get; set; }

        public Deck(Card[] cards)
        {
            if (cards == null || cards.Length == 0)
                throw new ArgumentException(nameof(cards));

            Count = cards.Length;
            _cards = new Stack<Card>(cards);
        }

        public Card Pull()
        {
            Count = _cards.Count - 1;
            return _cards.Pop();
        }
    }
}
