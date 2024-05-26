namespace artcollab.API.Monetization.Interfaces.REST;

public abstract class UserFactory
{
    public abstract void CreateUser(string name, string email, string password, string type, string username, ReaderSubscriptionStrategy subscriptionStrategy);
}