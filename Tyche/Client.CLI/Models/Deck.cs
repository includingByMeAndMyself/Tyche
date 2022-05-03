using System;
using System.Collections.Generic;


namespace Client.CLI.Models
{
    public class Deck
    {
        private Stack<Card> _cards;

        public Stack<Card> Cards { get { return _cards; } }

        public int Count { get; private set; }

        public string Name { get; private set; }

        public Deck(Card[] cards, string name)
        {
            if (cards == null || cards.Length == 0)
                throw new ArgumentException(nameof(cards));

            Count = cards.Length;
            _cards = new Stack<Card>(cards);
            Name = name;
        }

        public Card Pull()
        {
            Count = _cards.Count - 1;
            return _cards.Pop();
        }

        public virtual void ShowDeck()
        {
            Console.WriteLine(new string('-', 115));

            while(Cards.Count > 0)
            {
                var card = Cards.Pop();
                card.ShowCard();
            }

            Console.WriteLine(new string('-', 115));
        }
    }
}
