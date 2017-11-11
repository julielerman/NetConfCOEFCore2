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
     //samurai.Entrance = new Entrance (1, "Scene 1", "Caminando por una carretera comiendo una manzana");
      samurai.CreateEntrance (1, "Scene 1", "Caminando por una carretera comiendo una manzana");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

    private static void StoreNewSamuraiWithEntranceAndQuote () {
      var samurai = new Samurai ("Julie");

      samurai.CreateEntrance (1, "S1", "Explorando el vecindario, buscando a su perro");
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
        var quote = Samurai.AddQuote ("Todas esas manzanas te pondrán enfermo, perro tonto", 2);
        context.Add (quote);
        context.SaveChanges ();
      }
    }

  }
}