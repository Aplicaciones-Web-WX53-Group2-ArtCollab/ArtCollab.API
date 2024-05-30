using System.Net;
using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities
{
    public class PaymentObserver : Observer
    {
        public override HttpResponseMessage Update()
        {
            return new HttpResponseMessage( HttpStatusCode.Accepted) { Content = new StringContent("Payment Observer for update") };
        }
    
    }
}