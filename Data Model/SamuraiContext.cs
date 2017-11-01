using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;

namespace DataModel
{
    public class SamuraiContext:DbContext 
    {
        public DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=VegasSamurai.db");
         }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>().OwnsOne(s=>s.SecretIdentity);
        }
    }
}
