using Ametista.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ametista.Infrastructure.Persistence
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gemstone> Gemstones { get; set; }
        public DbSet<Mine> Mines { get; set; }
        public DbSet<Mining> Minings{ get; set; }
        public DbSet<Miner> Miners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gemstone>()
                .ToTable("Gemstones");

            modelBuilder.Entity<Mine>()
                .ToTable("Mines");

            modelBuilder.Entity<Mining>()
                .ToTable("Minings");

            modelBuilder.Entity<Miner>()
                .ToTable("Miners");
        }
    }
}
