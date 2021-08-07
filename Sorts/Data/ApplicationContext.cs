using Microsoft.EntityFrameworkCore;
using Sorts.Models;

namespace Sorts.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public ApplicationContext()
        {

        }
        public DbSet<SortingResult> Results { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SortsResults;Username=postgres;Password=1345");
            }
        }
    }
}
