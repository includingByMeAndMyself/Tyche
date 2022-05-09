using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> AddAsync(Deck deck, string name)
        {
            if (deck == null) return false;

            if (String.IsNullOrWhiteSpace(name)) return false;

            var deckEntity = _automapper.MappingToDeckEntity(deck, name);

            await _context.AddAsync(deckEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Deck> GetDeckAsync(string name)
        {
            var deckEntity = await _context.Decks.FirstOrDefaultAsync(deck => deck.Name == name);
            if (deckEntity == null) return null;

            deckEntity.Deck = await _context.Cards.Where(card => card.DeckId == deckEntity.Id).OrderByDescending(card => card.SequenceNumber).ToArrayAsync();

            var deck = _automapper.MappingToDeck(deckEntity, name);
            return deck;
        }

        public async Task<string[]> GetDecksNamesAsync()
        {
            var decksEntity = await _context.Decks.ToListAsync();
            var decks = new List<string>();

            foreach (var deck in decksEntity)
            {
                decks.Add(deck.Name);
            }
            return decks.ToArray();
        }

        public async Task<Deck[]> GetDecksAsync()
        {
            var decksEntity = await _context.Decks.ToListAsync();
            if (decksEntity.Count == 0) return null;

            foreach (var deckEntity in decksEntity)
            {
                deckEntity.Deck = await _context.Cards.Where(card => card.DeckId == deckEntity.Id).OrderByDescending(card => card.SequenceNumber).ToArrayAsync();
            }

            var decksResponse = new List<Deck>();

            foreach (var deck in decksEntity)
            {
                decksResponse.Add(_automapper.MappingToDeck(deck, deck.Name));
            }

            return decksResponse.ToArray();
        }

        public async Task<bool> DeleteAsync(string name)
        {
            var deck = await _context.Decks.FirstOrDefaultAsync(deck => deck.Name == name);
            if (deck == null) return false;

            _context.Decks.Remove(deck);

            var cardsEntity = await _context.Cards.Where(card => card.DeckId == deck.Id).ToArrayAsync();
            if (cardsEntity == null) return false;

            _context.Cards.RemoveRange(cardsEntity);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDecksAsync()
        {
            var decksEntity = _context.Decks.ToList();
            if (decksEntity.Count == 0) return false;

            foreach (var deckEntity in decksEntity)
            {
                await DeleteAsync(deckEntity.Name);
            }
            return true;
        }
    }
}
