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
    }

    static void StoreNewSamuraiWithEntrance () {
      var samurai = new Samurai ("Kojashi");

      samurai.Entrance = new Entrance (1, "Scene 1", "Caminando por una carretera comiendo una manzana");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

    private static void StoreNewSamuraiWithEntranceAndQuote () {
      var samurai = new Samurai ("Julie");
      samurai.Entrance = new Entrance (1, "Scene 1", "Explorando el vecindario, buscando a su perro");

      samurai.Quotes.Add (new Quote ("¿Has visto a mi perro?"));
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }
  }
}