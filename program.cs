using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataModel;
using SamuraiApp.Domain;

namespace SamuraiApp.Console {
  class Program {
    static void Main (string[] args) {
      using (var context = new SamuraiContext ()) {
        context.Database.Migrate ();
      }
      //StoreNewSamuraiWithEntrance ();
      //StoreNewSamuraiWithEntranceAndIdentity();
      //ListSamuraisWithEntranceAndIdentity();
    
     }
    
    // static void StoreNewSamuraiWithEntrance () {
    //   var samurai = new Samurai { Name = "Julie" };

    //   samurai.CreateEntrance (1, "S1", "Here I am!");
    //   using (var context = new SamuraiContext ()) {
    //     context.Samurais.Add (samurai);
    //     context.SaveChanges ();
    //   }
    // }

//     static void StoreNewSamuraiWithEntranceAndIdentity () {
//       var samurai = new Samurai { Name = "Giantpuppy" };
// samurai.Identify("Sampson","Newfie");
//       samurai.CreateEntrance (2, "S2", "Woof!");
//       using (var context = new SamuraiContext ()) {
//         context.Samurais.Add (samurai);
//         context.SaveChanges ();
//       }
//     }
    // static void ListSamuraisWithEntranceAndIdentity () {
    //   using (var context = new SamuraiContext ()) {
    //     var samurais = context.Samurais.Include ("Entrance").ToList ();
    //     foreach (var samurai in samurais) {
    //       Console.WriteLine ($"{samurai.Name}, Enters in {samurai.EntranceScene} ");
    //       Console.WriteLine ($"Secret Identity: {samurai.SecretIdentity.FullName()}");

    //     }
    //   }
    // }
       

  }
}