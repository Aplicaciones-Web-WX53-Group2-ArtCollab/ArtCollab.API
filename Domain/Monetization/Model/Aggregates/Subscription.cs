using Domain.Monetization.Model.Commands;

namespace Domain.Monetization.Model.Aggregates;

public partial class Subscription
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}

public partial class Subscription
{
    public Subscription()
    {
        
    }

    public Subscription(CreateSubscriptionCommand command)
    {
        IsActive = true;
    }
    
}