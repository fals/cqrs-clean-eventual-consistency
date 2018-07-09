using Ametista.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ametista.Infrastructure.Persistence
{
    public class AmetistaDbContext : DbContext
    {
        public AmetistaDbContext(DbContextOptions<AmetistaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gemstone> Student { get; set; }
    }
}
