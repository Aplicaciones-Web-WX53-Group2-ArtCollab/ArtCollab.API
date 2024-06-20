using Domain.Monetization.Model.Aggregates;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class CommisionResourceFromEntityAssembler
{
    public static CommisionResource ToResourceFromEntity(Commision commision)
    {
        return new CommisionResource(commision.Id, commision.Amount,commision.Content);
    }
}