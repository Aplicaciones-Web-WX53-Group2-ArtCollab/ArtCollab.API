using Domain.Monetization.Model.Aggregates;

namespace Domain.Monetization.Model.Entity;

public class PaymentObserver : Observer<Payment>
{
    public override void Update(Payment entity)
    {
        entity.Status = !entity.Status;
    }
    
}