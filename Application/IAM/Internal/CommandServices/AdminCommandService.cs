using Application.IAM.Internal.OutboundServices;
using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Commands;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Domain.Shared.Repositories;
using Shared;

namespace Application.IAM.Internal.CommandServices;

public class AdminCommandService(IUnitOfWork unitOfWork, IAdminRepository 
    adminRepository, ITokenService tokenService, IHashingService hashingService) : IAdminCommandService
{
    public async Task<(Admin admin, string token)> Handle(SignInCommand command)
    {
        var admin = await adminRepository.FindByUsernameAsync(command.Username);

        if (admin is null || !hashingService.VerifyPassword(command.Password, admin.PasswordHash))
            throw new InvalidUsernameOrPasswordException();

        var token = tokenService.GenerateToken(admin);

        return (admin, token);
    }

    public async Task Handle(SignUpCommand command)
    {
        if (adminRepository.ExistsByUsername(command.Username))
            throw new UsernameAlreadyTakenException($"Username {command.Username} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new Admin(command.Username, hashedPassword);
        try
        {
            await adminRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new ErrorOcurredWhileCreatingUserException($"An error occurred while creating the user: {e.Message}");
        }
    }
}