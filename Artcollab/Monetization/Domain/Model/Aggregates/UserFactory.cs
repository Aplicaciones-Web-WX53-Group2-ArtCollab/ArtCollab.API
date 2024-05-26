using Application.Monetization.Domain.Model.Entities;

namespace Application.Monetization.Domain.Model.Aggregates;

public abstract class UserFactory
{
    public abstract Reader CreateUser(string name, string email, string password, string username, ReaderSubscriptionStrategy subscriptionStrategy);
}