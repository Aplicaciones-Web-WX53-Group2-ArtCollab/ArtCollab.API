using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities
{
    public class PaymentObserver : Observer<Payment>
    {
        public override void Update(Payment entity)
        {
            entity.Status = !entity.Status;
        }
    
    }
}