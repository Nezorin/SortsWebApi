using Microsoft.EntityFrameworkCore;
using Sorts.Models;

namespace WebAPI.Data_Acces
{
    public class DataContext : DbContext
    {
        public DbSet<SortingResult> Results { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
