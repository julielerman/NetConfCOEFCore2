using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.Domain {
  public class Samurai {

    public Samurai(string name)
    {
        Name=name;
    }
    private Samurai () {
      Quotes = new List<Quote> ();
    }

    public int Id { get; private set; }
    public string Name { get; set; }
    public List<Quote> Quotes { get; set; } //1:*

    public Entrance Entrance { get; set; } //1:1
  
  }
}