using Application.Monetization.Domain.Model.Entities;

namespace Application.Monetization.Domain.Model.Aggregates;

public  abstract class Reader
{
    public  int Id { get; set; }
    public  string Name { get; set; }
    public  string Email { get; set; }
    public  string Password { get; set; }
    public  string Type { get; set; }
    public string Username { get; set; }
}

