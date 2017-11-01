namespace SamuraiApp.Domain
{
  public class Quote
  {
    public Quote(string quoteText, int samuraiId)
    {
      Text = quoteText;
      SamuraiId = samuraiId;
    }
    public int Id { get; private set; }
    public string Text { get; set; }
    public int SamuraiId { get; private set; }
  }
}