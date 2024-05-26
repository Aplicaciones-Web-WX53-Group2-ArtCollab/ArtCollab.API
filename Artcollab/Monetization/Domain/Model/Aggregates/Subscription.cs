namespace Application.Monetization.Domain.Model.Aggregates;

public abstract class Subscription
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}