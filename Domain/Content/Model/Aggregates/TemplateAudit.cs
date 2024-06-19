using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Domain.Content.Model.Aggregates;

public partial class Template : IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}