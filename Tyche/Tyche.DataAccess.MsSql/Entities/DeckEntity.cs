using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tyche.DataAccess.MsSql.Entities
{
    public class DeckEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<CardEntity> Deck { get; set; }
    }
}
