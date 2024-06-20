using Domain.User.Model.Aggregates;
using Domain.User.Model.Commands;

namespace Domain.User.Services;

public interface IReaderCommandService
{
    Task<Reader?> Handle(CreateReaderCommand command);
    Task<Reader?> Handle(UpdateReaderCommand command);
    Task<Reader?> Handle(DeleteReaderCommand command);
}