using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace DataModel {
  public class SamuraiContext : DbContext {
    public DbSet<Samurai> Samurais { get; set; }
    private DbSet<Quote> Quote { get; set; } //note this is private
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.Entity<Samurai> ().HasOne (typeof (Entrance), "Entrance");
      modelBuilder.Entity<Samurai> ().OwnsOne (typeof (PersonName), "SecretIdentity");
      base.OnModelCreating (modelBuilder);
    }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite ("Filename=VegasSamurai.db");
    }

    //let EF take care of its rule that you can't insert a samurai without
    //SOME instance of SecretIdentity added (ownedEntities cannot be null)
    public override int SaveChanges () {
      foreach (var entry in ChangeTracker.Entries ()
          .Where (e => e.Entity is Samurai && e.State == EntityState.Added)) {
        if (entry.Entity is Samurai samurai) {
          if (entry.Reference ("SecretIdentity").CurrentValue == null) {
            entry.Reference ("SecretIdentity").CurrentValue = PersonName.Empty ();
          }
        }
      }
      return base.SaveChanges ();
    }
  }
}