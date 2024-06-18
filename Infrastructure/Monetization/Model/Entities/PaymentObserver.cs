using System.Net;
using Infrastructure.Monetization.Model.Aggregates;

namespace Infrastructure.Monetization.Model.Entities
{
    public class PaymentObserver : Observer
    {
        public override HttpResponseMessage Update()
        {
            return new HttpResponseMessage( HttpStatusCode.Accepted) { Content = new StringContent("Payment IObserver for update") };
        }
    
    }
}