using Domain.Monetization.Model.Commands;

namespace Domain.Monetization.Model.Aggregates;

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
    }

    public Commision(CreateCommisionCommand command)
    {
        Amount = command.Amount;
        Content = command.Content;
        Date = DateTime.Now;
    }
}