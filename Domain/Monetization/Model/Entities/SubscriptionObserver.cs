using System.Net;
using Domain.Monetization.Model.Aggregates;
using Infrastructure.Monetization.Model.Aggregates;

namespace Infrastructure.Monetization.Model.Entities;

public class SubscriptionObserver : Observer
{
    public override HttpResponseMessage Update()
    {
        return new HttpResponseMessage( HttpStatusCode.Accepted) { Content = new StringContent("Subscription IObserver for update") };
    }
}