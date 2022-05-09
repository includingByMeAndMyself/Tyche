using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Tyche.BusinessLogic.Services;
using Tyche.Domain.Interfaces;
using Tyche.Domain.Models;


namespace Tyche.UnitTests
{
    public class DeckServiceTests
    {
        private DeckService _service;
        private Mock<IDeckRepository> _deckRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _deckRepositoryMock = new Mock<IDeckRepository>();
            _service = new DeckService(_deckRepositoryMock.Object);
        }

        [Test]
        public void GetDeckByName_ShouldReturnTrue()
        {
            //arrange
            var expectedDeckName = "TestDeck";

            var Cards = new List<Card>();
            var card1 = new Card(Rank.Ace, Suit.Diamonds, 1);
            var card2 = new Card(Rank.Ace, Suit.Spades, 2);

            Cards.Add(card1);
            Cards.Add(card2);

            var deck = new Deck(Cards.ToArray(), expectedDeckName);

            _deckRepositoryMock
                .Setup(x => x.GetDeckAsync(expectedDeckName))
                .ReturnsAsync(() => deck)
                .Verifiable();

            //act
            var result = _service.GetDeckByNameAsync(expectedDeckName);

            //assert
            _deckRepositoryMock.VerifyAll();

            Assert.AreEqual(expectedDeckName, result.Result.Name);
        }

        public void GetCreatedDecksNames_ShouldReturnTrue()
        {
            //arrange
            var expectedDeckName = "TestDeck";

            var Cards = new List<Card>();
            var card1 = new Card(Rank.Ace, Suit.Diamonds, 1);
            var card2 = new Card(Rank.Ace, Suit.Spades, 2);

            Cards.Add(card1);
            Cards.Add(card2);

            var deck = new Deck(Cards.ToArray(), expectedDeckName);

            _deckRepositoryMock
                .Setup(x => x.GetDecksNamesAsync())
                .ReturnsAsync(() => new string[] { expectedDeckName })
                .Verifiable();

            //act
            var result = _service.GetCreatedDecksNamesAsync();

            //assert
            _deckRepositoryMock.VerifyAll();

            Assert.NotNull(result.Result);
            Assert.IsNotEmpty(result.Result);
            Assert.AreEqual(expectedDeckName, result.Result[0]);
        }
    }
}