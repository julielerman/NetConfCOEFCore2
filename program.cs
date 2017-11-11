using System;
using System.Linq;
using System.Reflection;
using DataModel;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Console {
  class Program {
    static void Main (string[] args) {
      using (var context = new SamuraiContext ()) {
        context.Database.Migrate ();
      }
      StoreNewSamuraiWithEntrance ();
      StoreNewSamuraiWithEntranceAndQuote ();
      AddQuoteToSamurai ();
    }

    static void StoreNewSamuraiWithEntrance () {
      var samurai = new Samurai ("Kojashi");

      samurai.CreateEntrance (1, "Scene 1", "Walking up a road eating an apple");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

    private static void StoreNewSamuraiWithEntranceAndQuote () {
      var samurai = new Samurai ("Julie");

      samurai.CreateEntrance (1, "S1", "Wandering around neighborhood looking for her dog");
      samurai.AddQuote ("some quote");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

    static void AddQuoteToSamurai () {
      using (var context = new SamuraiContext ()) {
        //var samurai=context.Samurais.Find(1);
        //samurai.AddQuote("hello? hello?");
        var quote = Samurai.AddQuote ("All those apples will make you sick, silly boy", 2);
        context.Add (quote);
        context.SaveChanges ();
      }
    }

  }
}