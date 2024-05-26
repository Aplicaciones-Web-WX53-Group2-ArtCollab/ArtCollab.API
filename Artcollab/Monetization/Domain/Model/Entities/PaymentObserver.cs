using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities;

public class PaymentObserver : Observer<Payment>
{
    public override void Update(Payment entity)
    {
        entity.Status = !entity.Status;
    }
    
}