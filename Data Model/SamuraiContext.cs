using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace DataModel {
    public class SamuraiContext : DbContext {
        public DbSet<Samurai> Samurais { get; set; }
        private DbSet<Quote> Quote { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Samurai> ().HasOne (typeof (Entrance), "Entrance");
            base.OnModelCreating (modelBuilder);
        }
        
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
             optionsBuilder.UseSqlite("Filename=../DemoData/Samurai.db");
        }

    }
}