using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly CardShuffler _cardShuffler = new();

        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public async Task<string> CreateNamedDeckAsync(string name, DeckType deckType)
        {
            try
            {
                var existingDeck = await GetDeckByNameAsync(name);
                if (existingDeck != null) return $"Deck whit this name {name} already exists";

                var cards = GetCardsArray(deckType);
                var deck = new Deck(cards, name);

                var isCreate = await _deckRepository.AddAsync(deck, name);
                if (isCreate)
                    return "Success created";
                else
                    return "Deck not created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Deck> GetDeckByNameAsync(string name)
        {
            var deck = await _deckRepository.GetDeckAsync(name);
            return deck;
        }

        public async Task<string[]> GetCreatedDecksNamesAsync()
        {
            return await _deckRepository.GetDecksNamesAsync();
        }

        public async Task<Deck[]> GetDecksAsync()
        {
            return await _deckRepository.GetDecksAsync();
        }

        public async Task<string> DeleteDeckByNameAsync(string name)
        {
            try
            {
                var existingDeck = await GetDeckByNameAsync(name);
                if (existingDeck != null)
                {
                    await _deckRepository.DeleteAsync(name);
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

        public async Task<string> DeleteDecksAsync()
        {
            var decks = await _deckRepository.GetDecksAsync();
            if (decks == null) return "Decks was not created";

            await _deckRepository.DeleteDecksAsync();
            return "Success deleted";
        }

        public async Task<string> ShuffleDeckByNameAsync(int sortOption, string name)
        {
            var existingDeck = await GetDeckByNameAsync(name);

            if (existingDeck != null)
            {
                switch (sortOption)
                {
                    case SIMPLE_SHUFFLING:
                        await UpdateDeckAsync(name, _cardShuffler.SimpleShuffle(existingDeck));
                        break;
                    case ASCENDING_ORDER:
                        await DeleteDeckByNameAsync(name);
                        await CreateNamedDeckAsync(name, (DeckType)existingDeck.Count);
                        break;
                    default:
                        await UpdateDeckAsync(name, _cardShuffler.SimpleShuffle(existingDeck));
                        break;
                }
                return "Successfully shuffled";
            }
            else
                return "This decks was not created";
        }

        private async Task UpdateDeckAsync(string name, Deck deck)
        {
            await DeleteDeckByNameAsync(name);
            await _deckRepository.AddAsync(deck, name);
        }

        private static Card[] GetCardsArray(DeckType deckType)
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
