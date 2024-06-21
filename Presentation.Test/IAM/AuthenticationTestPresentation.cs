
using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Commands;
using Domain.IAM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.IAM.REST;
using Presentation.IAM.REST.Resources;

namespace Presentation.Test.IAM;

public class AuthenticationTestPresentation
{
    [Fact]
    public async Task SignInWorking()
    {
        //Arrange
        var mockAdminCommandService = new Mock<IAdminCommandService>();
        var command = new SignInCommand("admin", "admin");
        var admin = new Admin("admin", "admin");
        var controller = new AuthenticationController(mockAdminCommandService.Object);
        var authenticatedUserResource = new AuthenticatedAdminResource(admin.Id, admin.Username, "ExampleToken");
        var signInResource = new SignInResource(admin.Username, admin.PasswordHash);
    
        //Act
        mockAdminCommandService.Setup(x => x.Handle(command)).ReturnsAsync((admin, "ExampleToken"));
        var result = await controller.SignIn(signInResource);
    
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<AuthenticatedAdminResource>(okResult.Value);
        Assert.NotNull(model);
        Assert.Equal(authenticatedUserResource.Id, model.Id);
        Assert.Equal(authenticatedUserResource.Username, model.Username);
        Assert.Equal(authenticatedUserResource.Token, model.Token);
    }

    [Fact]
    public async Task SignUpWorking()
    {
        //Arrange
        var mockAdminCommandService = new Mock<IAdminCommandService>();
        var command = new SignUpCommand("admin", "admin");
        var admin = new Admin("admin", "admin");
        var controller = new AuthenticationController(mockAdminCommandService.Object);
        var signUpResource = new SignUpResource(admin.Username, admin.PasswordHash);

        //Act
        mockAdminCommandService.Setup(x => x.Handle(command)).Returns(Task.CompletedTask);
        var result = await controller.SignUp(signUpResource);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}