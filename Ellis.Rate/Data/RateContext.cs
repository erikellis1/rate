using Ellis.Rate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ellis.Rate.Data
{
    public class RateContext : DbContext
    {
        public RateContext(DbContextOptions<RateContext> options) : base(options) { }

        public DbSet<RatedItem> RatedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RatedItem>()
                .ToTable("RatedItems");
        }
    }
}

namespace Ellis.Rate.Data.Models
{
}