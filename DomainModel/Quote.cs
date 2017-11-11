namespace SamuraiApp.Domain
{
  public class Quote
  {
    public Quote(){}
    public Quote(string quoteText)
    {
      Text = quoteText;
     
    }
    public int Id { get; private set; }
    public string Text { get; set; }
    public int SamuraiId { get; private set; }
  }
}