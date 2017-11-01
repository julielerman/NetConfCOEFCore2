using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain {
  public class Samurai {

    public Samurai () {
      Quotes = new List<Quote> ();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Quote> Quotes { get; set; } //1:*

    public Entrance Entrance { get; set; } //1:1
    
    public PersonName SecretIdentity { get; private set; } //value object
    public void Identify (string first, string last) 
    {
      SecretIdentity = PersonName.Create (first, last);
    }
  }
}