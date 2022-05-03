using System;
using System.Collections.Generic;
using Tyche.BusinessLogic.Infrasturcure;
using Tyche.Domain.Interfaces;
using Tyche.Domain.Models;


namespace Tyche.BusinessLogic.Services
{
    public class DeckService : IDeckService
    {
        private const int SIMPLE_SHUFFLING = 1;
        private const int ASCENDING_ORDER = 2;

        private readonly IDeckRepository _deckRepository;
        private readonly CardShuffler _cardShuffler = new CardShuffler();

        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public string CreateNamedDeck(string name, DeckType deckType)
        {
            try
            {
                var existingDeck = GetDeckByName(name);
                if (existingDeck != null) return $"Deck this name {name} already exists";

                var cards = GetCardsArray(deckType);
                var deck = new Deck(cards, name);

                _deckRepository.Add(deck, name);
                return "Success created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Deck GetDeckByName(string name)
        {
            var deck = _deckRepository.GetDeck(name);
            return deck;
        }

        public string[] GetCreatedDecksNames()
        {
            return _deckRepository.GetDecksNames();
        }

        public Deck[] GetDecks()
        {
            return _deckRepository.GetDecks();
        }

        public string DeleteDeckByName(string name)
        {
            try
            {
                var existingDeck = GetDeckByName(name);
                if (existingDeck != null)
                {
                    _deckRepository.Delete(name);
                    return "Success deleted";
                }
                else
                    return "This deck was not created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteDecks()
        {
            var decks = _deckRepository.GetDecks();
            if (decks == null) return "Decks was not created";

            _deckRepository.DeleteDecks();
            return "Success deleted";
        }

        public string ShuffleDeckBySuit(int sortOption, string name)
        {
            var existingDeck = GetDeckByName(name);

            if (existingDeck != null)
            {
                switch (sortOption)
                {
                    case SIMPLE_SHUFFLING:
                        UpdateDeck(name, _cardShuffler.SimpleShuffle(existingDeck));
                        break;
                    case ASCENDING_ORDER:
                        DeleteDeckByName(name);
                        CreateNamedDeck(name, (DeckType)existingDeck.Count);
                        break;
                    default:
                        UpdateDeck(name, _cardShuffler.SimpleShuffle(existingDeck));
                        break;
                }
                return "Successfully shuffled";
            }
            else
                return "This decks was not created";
        }

        private void UpdateDeck(string name, Deck deck)
        {
            DeleteDeckByName(name);
            _deckRepository.Add(deck, name);
        }

        private Card[] GetCardsArray(DeckType deckType)
        {
            var cards = new List<Card>();
            var sequenceNumber = 1;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (deckType == DeckType.SmalDeck)
                    {
                        if (rank < Rank.Six)
                            continue;
                    }

                    cards.Add(new Card(rank, suit, sequenceNumber));
                    sequenceNumber++;
                }
            }
            return cards.ToArray();
        }
    }
}
