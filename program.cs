using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataModel;
using SamuraiApp.Domain;
using System.Reflection;

namespace SamuraiApp.Console
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var context = new SamuraiContext())
      {
        context.Database.Migrate();
      }
      StoreNewSamuraiWithEntrance ();
      //StoreNewSamuraiWithEntranceAndQuote();
      // StoreNewSamuraiWithEntranceAndIdentity();
      //ListSamuraisWithEntranceAndIdentity();
      //AddQuoteToSamurai();
      //ReplaceValueObjectFails();
      //ReplaceValueObject();
    }


    
    static void StoreNewSamuraiWithEntrance()
    {
      // var samurai = new Samurai("Kojashi" );

      // samurai.CreateEntrance(1, "Scene 1", "Walking up a road eating an apple");
      // using (var context = new SamuraiContext())
      // {
      //   context.Samurais.Add(samurai);
      //   context.SaveChanges();
      // }
    }

    private static void StoreNewSamuraiWithEntranceAndQuote()
    {
      // var samurai = new Samurai("Julie");

      // samurai.CreateEntrance(1, "S1", "Wandering around neighborhood looking for her dog");
      // using (var context = new SamuraiContext())
      // {
      //   context.Samurais.Add(samurai);
      //   context.SaveChanges();
      // }
    }
    static void StoreNewSamuraiWithEntranceAndIdentity()
    {
      // var samurai = new Samurai ("Giantpuppy");
      // samurai.Identify("Sampson", "Newfie");
      // samurai.CreateEntrance(2, "S2", "Eating apples under the apple trees");
      // using (var context = new SamuraiContext())
      // {
      //   context.Samurais.Add(samurai);
      //   context.SaveChanges();
      // }
    }

    static void AddQuoteToSamurai()
    {
      // using (var context = new SamuraiContext())
      // {
      //   var samurai=context.Samurais.Find(1);
      //   samurai.AddQuote("hello? hello?");
      //   var quote=Samurai.AddQuote("All those apples will make you sick, silly boy", 2);
      //   context.Add(quote);
      //   context.SaveChanges();
      // }
    }
   static void ReplaceValueObjectFails()
     {
    //   //workaround for current failing in owned entities
    //   using (var context = new SamuraiContext())
    //   {
    //     var samurai = context.Samurais.FirstOrDefault();
    //      samurai.Identify("new", "identity");
    //     context.SaveChanges();
    //   }
    }
    static void ReplaceValueObject()
    {
      // //workaround for current failing in owned entities
      // using (var context = new SamuraiContext())
      // {
      //   var samurai = context.Samurais.FirstOrDefault();
      //   //if SecretIdentity was public, I could:
      //   //context.Entry(samurai.SecretIdentity).State = EntityState.Detached;

      //   //but it's private, so isn't public in my domain so I have to work harder at this

      //   var originalpersonName = context.Entry(samurai).Reference("SecretIdentity").CurrentValue;
      //   context.Entry(originalpersonName).State = EntityState.Detached;
      //   samurai.Identify("new", "identity");
      //   var updatedPersonName = context.Entry(samurai).Reference("SecretIdentity").CurrentValue;

      //   context.Entry(updatedPersonName).State = EntityState.Modified;

      //   context.SaveChanges();
      // }
    }
  }
}