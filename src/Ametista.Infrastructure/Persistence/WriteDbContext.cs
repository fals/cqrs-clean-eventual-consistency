using Ametista.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ametista.Infrastructure.Persistence
{
    public class WriteDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
