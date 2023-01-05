﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabasesContext : DbContext
    {
        public DbSet<DB> Databeses { get; set; }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DatabasesContext(DbContextOptions<DatabasesContext> options) : base(options)
        {
        }

        
    }
}