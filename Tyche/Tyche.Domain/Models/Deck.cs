using System;
using System.Collections.Generic;


namespace Tyche.Domain.Models
{
    public class Deck
    {
        private Stack<Card> _cards;

        public int Id { get; set; }

        public Suit Name { get; set; }

        public Deck(Card[] cards)
        {
            if (cards == null || cards.Length == 0)
                throw new ArgumentException(nameof(cards));

            _cards = new Stack<Card>(cards);
        }

        public Card Pull()
        {
            return _cards.Pop();
        }
    }
}
