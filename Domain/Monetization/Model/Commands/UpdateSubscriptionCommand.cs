namespace Domain.Monetization.Model.Commands;

public record UpdateSubscriptionCommand(int Id, bool IsActive);