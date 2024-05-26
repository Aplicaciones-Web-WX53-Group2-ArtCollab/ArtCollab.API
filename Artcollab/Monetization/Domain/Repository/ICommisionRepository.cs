using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Shared.Domain.Repositories;

namespace Application.Monetization.Domain.Repository;

public interface ICommisionRepository :IBaseRepository<Commision>
{
    public Task<Commision> GetCommisionByDate(DateTime date);
    public Task<Commision> GetCommisionByAmount(double amount);
    public Task<Commision> GetCommisionByContent(string content);
}