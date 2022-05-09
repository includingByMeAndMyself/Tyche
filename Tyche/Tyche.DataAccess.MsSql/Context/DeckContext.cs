using Microsoft.EntityFrameworkCore;
using Tyche.DataAccess.MsSql.Entities;

namespace Tyche.DataAccess.MsSql.Context
{
    public class DeckContext : DbContext
    {
        public DbSet<DeckEntity> Decks { get; set; }
        public DbSet<CardEntity> Cards { get; set; }

        public DeckContext(DbContextOptions<DeckContext> options) : base(options)
        {

        }

    }
}
