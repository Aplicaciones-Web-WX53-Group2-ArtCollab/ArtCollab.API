using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Domain.User.Model.Aggregates;

public partial class Reader : IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}