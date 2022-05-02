using System;
using System.Collections.Generic;
using Tyche.DataAccess.MsSql.Entities;
using Tyche.Domain.Models;


namespace Tyche.DataAccess.MsSql.Infrastructure
{
    public class Automapper
    {
        public DeckEntity MappingToDeckEntity(Deck deck)
        {
            var cards = new List<CardEntity>();

            while (deck.Count > 0)
            {
                var card = deck.Pull();
                var cardEntity = new CardEntity
                {
                    Rank = card.Rank.ToString(),
                    Suit = card.Suit.ToString()
                };
                cards.Add(cardEntity);
            }

            var suit = deck.Suit.ToString();

            return new DeckEntity
            {
                Suit = suit,
                Deck = cards.ToArray()
            };
        }

        public Deck MappingToDeck(DeckEntity deckEntity)
        {
            var cards = new List<Card>();
            var decks = deckEntity.Deck;

            foreach (var item in decks)
            {
                var rank = (Rank)Enum.Parse(typeof(Rank), item.Rank);
                var suit = (Suit)Enum.Parse(typeof(Suit), item.Suit);
                
                var card = new Card(rank, suit);
                
                cards.Add(card);
            }

            return new Deck(cards.ToArray());
        }
    }
}
