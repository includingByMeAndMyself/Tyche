using System;
using System.Collections.Generic;
using System.Linq;
using Tyche.DataAccess.MsSql.Context;
using Tyche.DataAccess.MsSql.Infrastructure;
using Tyche.Domain.Interfaces;
using Tyche.Domain.Models;


namespace Tyche.DataAccess.MsSql.Repository
{
    public class DeckRepository : IDeckRepository
    {
        private readonly DeckContext _context;
        private readonly Automapper _automapper = new Automapper();

        public DeckRepository(DeckContext context)
        {
            _context = context;
        }

        public void Add(Deck deck, string name)
        {
            if (deck == null) return;

            if (String.IsNullOrWhiteSpace(name)) return;

            var deckEntity = _automapper.MappingToDeckEntity(deck, name);

            _context.Add(deckEntity);
            _context.SaveChanges();
        }

        public Deck GetDeck(string name)
        {
            var deckEntity = _context.Decks.FirstOrDefault(deck => deck.Name == name);
            if (deckEntity == null) return null;

            deckEntity.Deck = _context.Cards.Where(card => card.DeckId == deckEntity.Id).OrderByDescending(card => card.SequenceNumber).ToArray();

            var deck = _automapper.MappingToDeck(deckEntity, name);
            return deck;
        }

        public string[] GetDecksNames()
        {
            var decksEntity = _context.Decks.ToList();
            var decks = new List<string>();

            foreach (var deck in decksEntity)
            {
                decks.Add(deck.Name);
            }
            return decks.ToArray();
        }

        public Deck[] GetDecks()
        {
            var decksEntity = _context.Decks.ToList();
            if (decksEntity.Count == 0) return null;

            foreach (var deckEntity in decksEntity)
            {
                deckEntity.Deck = _context.Cards.Where(card => card.DeckId == deckEntity.Id).OrderByDescending(card => card.SequenceNumber).ToArray();
            }

            var decksResponse = new List<Deck>();

            foreach (var deck in decksEntity)
            {
                decksResponse.Add(_automapper.MappingToDeck(deck, deck.Name));
            }

            return decksResponse.ToArray();
        }

        public void Delete(string name)
        {
            var deck = _context.Decks.FirstOrDefault(deck => deck.Name == name);
            _context.Decks.Remove(deck);

            var cardsEntity = _context.Cards.Where(card => card.DeckId == deck.Id).ToArray();
            _context.Cards.RemoveRange(cardsEntity);

            _context.SaveChanges();
        }

        public void DeleteDecks()
        {
            var decksEntity = _context.Decks.ToList();
            if (decksEntity.Count == 0) return;

            foreach (var deckEntity in decksEntity)
            {
                Delete(deckEntity.Name);
            }
        }
    }
}
