using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.Domain {
  public class Samurai {

    public Samurai (string name) {
      Name = name;
    }
    private Samurai () {
      //Quotes = new List<Quote> ();
    }

    public int Id { get; private set; }
    public string Name { get; set; }

    // public List<Quote> Quotes { get; set; } //1:*
    private readonly List<Quote> _quotes = new List<Quote> ();
    public IEnumerable<Quote> Quotes => _quotes.ToList ();
    public void AddQuote (string quoteText) {
      //TODO: Remove naughty words
      var newQuote = new Quote (quoteText, Id);
      _quotes.Add (newQuote);
    }
    public static Quote AddQuote (string quoteText, int samuriId) {
      //TODO: Remove naughty words
      var newQuote = new Quote (quoteText, samuriId);
      return newQuote;
    }

    //public Entrance Entrance { get; set; } //1:1

    //___Backing Field_____
    // private Entrance _entrance; 
    // private Entrance Entrance => _entrance;
    // public void CreateEntrance (int minute, string sceneName, string description) {
    //    _entrance = new Entrance (minute, sceneName, description);
    //  }
    //  public string EntranceScene => _entrance?.SceneName;

    //___Inferred Backing Field_____
    private Entrance Entrance { get; set; }
    public void CreateEntrance (int minute, string sceneName, string description) {
      Entrance = new Entrance (minute, sceneName, description);
    }
    public string EntranceScene => Entrance?.SceneName;
  }
}