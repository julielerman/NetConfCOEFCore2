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
      AddQuoteToExistingSamurai ();
    }

    static void StoreNewSamuraiWithEntrance () {
      var samurai = new Samurai ("Kojashi2");
     //samurai.Entrance = new Entrance (1, "Scene 1", "Caminando por una carretera comiendo una manzana");
       samurai.CreateEntrance (1, "Scene 2", "Caminando por una carretera comiendo una manzana");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

    private static void StoreNewSamuraiWithEntranceAndQuote () {
      var samurai = new Samurai ("Julie2");
     //samurai.Entrance = new Entrance (1, "Scene 1", "Explorando el vecindario, buscando a su perro");
     //samurai.Quotes.Add (new Quote ("¿Has visto a mi perro?"));
      samurai.CreateEntrance (1, "S2", "Explorando el vecindario, buscando a su perro");
      samurai.AddQuote ("mas quote");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

    static void AddQuoteToExistingSamurai () {
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