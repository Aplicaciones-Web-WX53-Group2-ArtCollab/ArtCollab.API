using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Monetization.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    
}