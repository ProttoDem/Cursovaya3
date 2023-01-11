using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabasesContext : DbContext
    {
        public DbSet<DBInfo> Databeses { get; set; }
        public DbSet<User> Users { get; set; } = null!;

        public DatabasesContext(DbContextOptions<DatabasesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
        }

    }
}