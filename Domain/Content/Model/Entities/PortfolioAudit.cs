using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Domain.Content.Model.Entities;

public partial class Portfolio : IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}