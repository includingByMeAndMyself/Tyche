using System.Collections.Generic;


namespace Tyche.DataAccess.MsSql.Entities
{
    public class DeckEntity
    {
        public int Id { get; set; }

        public string Suit { get; set; }

        public ICollection<CardEntity> Deck { get; set; }
    }
}
