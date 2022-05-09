using System;
using System.Collections.Generic;
using Tyche.DataAccess.MsSql.Entities;
using Tyche.Domain.Models;


namespace Tyche.DataAccess.MsSql.Infrastructure
{
    internal class Automapper
    {
        public DeckEntity MappingToDeckEntity(Deck deck, string name)
        {
            var cards = new List<CardEntity>();

            foreach (var card in deck.Cards)
            {
                var cardEntity = new CardEntity
                {
                    Rank = card.Rank.ToString(),
                    Suit = card.Suit.ToString(),
                    SequenceNumber = card.SequenceNumber
                };
                cards.Add(cardEntity);
            }

            return new DeckEntity
            {
                Name = name,
                Deck = cards.ToArray()
            };
        }

        public Deck MappingToDeck(DeckEntity deckEntity, string name)
        {
            var cards = new List<Card>();
            var decks = deckEntity.Deck;
            var sequenceNumber = 1;

            foreach (var deck in decks)
            {
                var rank = (Rank)Enum.Parse(typeof(Rank), deck.Rank);
                var suit = (Suit)Enum.Parse(typeof(Suit), deck.Suit);

                var card = new Card(rank, suit, deck.SequenceNumber);
                sequenceNumber++;
                cards.Add(card);
            }

            return new Deck(cards.ToArray(), name);
        }
    }
}
