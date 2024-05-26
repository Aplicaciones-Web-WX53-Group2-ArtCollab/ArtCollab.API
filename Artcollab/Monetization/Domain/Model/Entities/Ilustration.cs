using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities;

public partial class Ilustration : Reader
{
    public  int Id { get; set; }
    public  string Name { get; set; }
    public  string Email { get; set; }
    public  string Password { get; set; }
    public  string Type { get; set; }
    public  string Username { get; set; }
    public IlustrationSubscriptionStrategy SubscriptionStrategy { get; set; }
}

public partial class Ilustration
{
    public Ilustration()
    {
        Type = "Ilustration";
        Name = " ";
        Email = " ";
        Password = " ";
        Username = " ";
        SubscriptionStrategy = new IlustrationSubscriptionStrategy();
        
    }
}