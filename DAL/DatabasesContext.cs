using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabasesContext : DbContext
    {
        public DbSet<DB> Databeses { get; set; } = null!;

        public DatabasesContext(DbContextOptions<DatabasesContext> options) : base(options)
        {
        }
    }
}