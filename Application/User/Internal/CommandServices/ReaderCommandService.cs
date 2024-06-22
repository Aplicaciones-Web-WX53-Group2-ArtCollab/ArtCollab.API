using Domain.Shared.Repositories;
using Domain.User.Model.Aggregates;
using Domain.User.Model.Commands;
using Domain.User.Model.ValueObjects;
using Domain.User.Repositories;
using Domain.User.Services;
using Shared;

namespace Application.User.Internal.CommandServices;

public class ReaderCommandService(IUnitOfWork unitOfWork, IReaderRepository readerRepository) : IReaderCommandService
{
    public async Task<Reader?> Handle(CreateReaderCommand command)
    {
        var reader = new Reader(command);
        if (readerRepository.ReaderExistsByUsername(command.Username))
        {
            throw new UsernameAlreadyTakenException("Username already exists");
        }
        if (readerRepository.ReaderExistsByEmailAndPassword(command.Email,command.Password))
        {
            throw new AccountAlreadyExistsException();
        }

        if (!Enum.GetNames(typeof(EReaderTypes)).Any(e => e.ToLower() == command.Type.ToLower()))
        {
            throw new InvalidReaderTypeException();
        }
       
        await readerRepository.AddAsync(reader);
        await unitOfWork.CompleteAsync();
        return reader;
    }

    public async Task<Reader?> Handle(UpdateReaderCommand command)
    {
        var reader = await readerRepository.GetByIdAsync(command.Id);
        if (reader == null)
        {
            throw new ReaderDoesntExistException("Reader doesnt exist");
        }
        reader.Name = command.Name;
        reader.Username = command.Username;
        reader.Email = command.Email;
        reader.Password = command.Password;
        reader.ImgUrl = command.ImgUrl;
        reader.Type = command.Type;
        reader.UpdatedDate = DateTime.Now;
        readerRepository.Update(reader);
        await unitOfWork.CompleteAsync();
        return reader;
    }

    public async Task<Reader?> Handle(DeleteReaderCommand command)
    {
        var reader = await readerRepository.GetByIdAsync(command.Id);
        if (reader == null)
        {
            throw new Exception("Reader doesnt exist");
        }
        readerRepository.Delete(reader);
        await unitOfWork.CompleteAsync();
        return reader;
    }
}