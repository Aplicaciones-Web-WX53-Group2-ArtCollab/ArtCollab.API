using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Monetization.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    public async Task<IEnumerable<Subscription?>> GetAllActiveAsync(bool isActive)
    {
        return await context.Set<Subscription>().Where(x => x.IsActive == isActive).ToListAsync();
    }
}