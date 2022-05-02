using System;
using System.Collections.Generic;
using Tyche.Domain.Interfaces;
using Tyche.Domain.Models;


namespace Tyche.BusinessLogic.Services
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;

        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public string CreateNamedDeck(Suit suit)
        {
            try
            {
                var existingDecks = GetCreatedDecksSuits();
                
                if (existingDecks.Length != 0)
                {
                    foreach (var existingSuit in existingDecks)
                    {
                        if (existingSuit == suit.ToString())
                            return "Deck already exists";
                    }
                }

                var cards = GetCardsArray(suit);
                var deck = new Deck(cards);

                _deckRepository.Add(deck);
                return "Success created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Deck GetDeckBySuit(Suit suit)
        {
            var deck = _deckRepository.GetDeck(suit);
            return deck;
        }

        public Deck[] GetDecks()
        {
            return new Deck[] { };
        }

        public string[] GetCreatedDecksSuits()
        {
            return _deckRepository.GetDecksSuit();
        }

        public string DeleteDeckBySuit(Suit suit)
        {
            return "Success deleted";
        }

        public string ShuffleDeckBySuit(Suit suit, int sortOption)
        {
            return "Successfully shuffled";
        }

        private void Update()
        {

        }

        private Card[] GetCardsArray(Suit suit)
        {
            List<Card> listCards = new List<Card>();

            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                listCards.Add(new Card(rank, suit));
            }

            return listCards.ToArray();
        }
    }
}
