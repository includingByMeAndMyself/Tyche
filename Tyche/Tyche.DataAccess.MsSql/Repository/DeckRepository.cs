using System.Collections.Generic;
using System.Linq;
using Tyche.DataAccess.MsSql.Context;
using Tyche.DataAccess.MsSql.Entities;
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

        public void Add(Deck deck)
        {
            if (deck == null) return;

            var deckEntity = _automapper.MappingToDeckEntity(deck);

            _context.Add(deckEntity);
            _context.SaveChanges();
        }

        public void Delete(Suit suit)
        {
            throw new System.NotImplementedException();
        }

        public Deck[] Get()
        {
            var decksEntity = _context.Decks.ToList();
            return new Deck[] { };
        }

        public Deck GetDeck(Suit suit)
        {
            var cardsEntity = _context.Cards.Where(x => x.Suit == suit.ToString()).ToArray();
            if (cardsEntity.Length == 0) return null;

            var deckEntity = new DeckEntity
            {
                Deck = cardsEntity,
                Suit = suit.ToString()
            };

            var deck = _automapper.MappingToDeck(deckEntity);
            return deck;
        }

        public string[] GetDecksSuit()
        {
            var decksEntity = _context.Decks.ToList();
            var decks = new List<string>();

            foreach (var deck in decksEntity)
            {
                decks.Add(deck.Suit);
            }
            return decks.ToArray();
        }

        public void Update(Deck deck)
        {
            throw new System.NotImplementedException();
        }
    }
}
