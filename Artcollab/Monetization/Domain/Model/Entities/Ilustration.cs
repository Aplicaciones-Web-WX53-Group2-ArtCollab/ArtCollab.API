using Application.Monetization.Domain.Model.Aggregates;
using artcollab.API.Monetization.Interfaces.REST;

namespace Application.Monetization.Domain.Model.Entities;

public partial class Ilustration : Reader
{
    public  int Id { get; set; }
    public  string Name { get; set; }
    public  string Email { get; set; }
    public  string Password { get; set; }
    public  string Type { get; set; }
    public  string Username { get; set; }
    public new ReaderSubscriptionStrategy SubscriptionStrategy { get; set; }
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
        SubscriptionStrategy = new ReaderSubscriptionStrategy();
        
    }
}