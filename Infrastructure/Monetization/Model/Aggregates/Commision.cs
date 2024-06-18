namespace Infrastructure.Monetization.Model.Aggregates;

public partial class Commision
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public string Content { get; set; }
    
     
    public DateTime Date { get; set; }
}

public partial class Commision
{
    public Commision()
    {
        Amount = 0.00;
        Content = string.Empty;
        Date = DateTime.Now;
    }
}