using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities;

public partial class Writer : Reader
{
    public int Id { get; set; }
    public  string Name { get; set; }
    public  string Email { get; set; }
    public  string Password { get; set; }
    public  string Type { get; set; }
    public  string Username { get; set; }
    public  WriterSubscriptionStrategy SubscriptionStrategy { get; set; }
}

public partial class Writer
{
    public Writer()
    {
        Type = "Writer";
        Name = " ";
        Email = " ";
        Password = " ";
        Username = " ";
        SubscriptionStrategy = new WriterSubscriptionStrategy();
        
    }
}