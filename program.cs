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
          
       StoreNewSamuraiWithEntranceAndIdentity();
       ReplaceValueObject();
    }

    //Identity is NULL
    static void StoreNewSamuraiWithEntrance () {
      var samurai = new Samurai ("Kojashi3");
       samurai.CreateEntrance (1, "Scene 3", "Caminando por una carretera comiendo una manzana");
      using (var context = new SamuraiContext ()) {
        context.Samurais.Add (samurai);
        context.SaveChanges ();
      }
    }

     //Explanation of EF Core 2 and Value Objects
     //msdn.microsoft.com/magazine/mt826347
     static void StoreNewSamuraiWithEntranceAndIdentity()
    {
      var samurai = new Samurai ("Giantpuppy");
      samurai.Identify("Sampson", "Newfie");
      samurai.CreateEntrance(3, "S3", "Comiendo manzanas debajo de los manzanos");
      using (var context = new SamuraiContext())
      {
        context.Samurais.Add(samurai);
        context.SaveChanges();
      }
    }

    //Explanation at github.com/aspnet/EntityFrameworkCore/issues/9803
    static void ReplaceValueObject()
    {
      //workaround for current failing in owned entities
      using (var context = new SamuraiContext())
      {
        var samurai = context.Samurais.FirstOrDefault();
        //if SecretIdentity was public, I could:
       // context.Entry(samurai.SecretIdentity).State = EntityState.Detached;

        //but it's private, so isn't public in my domain so I have to work harder at this
         var originalpersonName = context.Entry(samurai).Reference("SecretIdentity").CurrentValue;
         context.Entry(originalpersonName).State = EntityState.Detached;
        samurai.Identify("primero", "último");
        var updatedPersonName = context.Entry(samurai).Reference("SecretIdentity").CurrentValue;

        context.Entry(updatedPersonName).State = EntityState.Modified;

        context.SaveChanges();
      }
    }
     static void ListSamuraisWithEntranceAndIdentity () {
      using (var context = new SamuraiContext ()) {
        var samurais = context.Samurais.Include ("Entrance").ToList ();
        foreach (var samurai in samurais) {
          System.Console.WriteLine($"{samurai.Name}, Enters in {samurai.EntranceScene} ");
  
          System.Console.WriteLine ($"Secret Identity: {samurai.RevealSecretIdentity()}");
          System.Console.WriteLine();
        }
      }
     }

  }
}