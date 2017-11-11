using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.Domain {
  public class Samurai {

    public Samurai (string name) {
      Name = name;
    }
    private Samurai () { }

    public int Id { get; private set; }
    public string Name { get; set; }
   
    //totally encapsulated 1:* relationship
    private readonly List<Quote> _quotes = new List<Quote> ();
    public IEnumerable<Quote> Quotes => _quotes.ToList ();
    public void AddQuote (string quoteText) {
      //TODO: Remove naughty words
      var newQuote = new Quote (quoteText, Id);
      _quotes.Add (newQuote);
    }

    //static method to allow adding quotes to a samurai without an instance
    public static Quote AddQuote (string quoteText, int samuriId) {
      //TODO: Remove naughty words
      var newQuote = new Quote (quoteText, samuriId);
      return newQuote;
    }

    //Totally encapsulated 1:1 relationship
    //HasOne mapping added to context because entrance is not a discoverable property 
    private Entrance Entrance { get; set; }
    public void CreateEntrance (int minute, string sceneName, string description) {
      Entrance = new Entrance (minute, sceneName, description);
    }
    public string EntranceScene => Entrance?.SceneName;

    //totally encapsulated private valueobject (mapped as ownedentity of samurai)
    private PersonName SecretIdentity { get; set; }
    public string RevealSecretIdentity () {
      if (SecretIdentity.IsEmpty ()) {
        return "It's a secret";
      } else {
        return SecretIdentity.FullName ();
      }
    }
    public void Identify (string first, string last) {
      SecretIdentity = PersonName.Create (first, last);
    }

  }

}