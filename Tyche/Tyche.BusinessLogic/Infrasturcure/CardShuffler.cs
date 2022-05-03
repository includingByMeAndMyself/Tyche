using System;
using System.Collections.Generic;
using System.Linq;
using Tyche.Domain.Models;


namespace Tyche.BusinessLogic.Infrasturcure
{
    internal class CardShuffler
    {
        protected static Random _random = new Random();

        //public Deck SimpleShuffle(Deck[] decks)
        //{
        //    var count = 0;

        //    foreach (var deck in decks)
        //    {
        //        count+=deck.Count;
        //    }

        //    int[] randomRanks = Enumerable.Range(0, count)
        //                                    .OrderBy(n => _random.Next(0, count))
        //                                    .ToArray();

        //    List<Card> cards = new List<Card>();

        //    foreach (var rank in randomRanks)
        //    {
        //        if (Enum.IsDefined(typeof(Rank), rank))
        //        {
        //            cards.Add(new Card((Rank)rank, suit));
        //        }
        //    }

        //    return new Deck(cards.ToArray());
        //}
    }
}
