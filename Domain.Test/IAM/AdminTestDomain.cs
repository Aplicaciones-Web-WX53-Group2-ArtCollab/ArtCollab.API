using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Commands;
using Domain.IAM.Services;
using Moq;

namespace Domain.Test.IAM;

public class AdminTestDomain
{
    [Fact]
    public async Task SignInWorking()
    {
        //Arrange
        var mockAdminCommandService = new Mock<IAdminCommandService>();
        var command = new SignInCommand("ExampleUser", "SuperSecret");
        //Act
        mockAdminCommandService.Setup(x => x.Handle(command)).ReturnsAsync(new ValueTuple<Admin, string>(new Admin(), "ExampleToken"));
        var result = await mockAdminCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SignUpWorking()
    {
        //Arrange
        var mockAdminCommandService = new Mock<IAdminCommandService>();
        var command = new SignUpCommand("ExampleUser", "Super");
        //Act
        mockAdminCommandService.Setup(x => x.Handle(command)); 
        await mockAdminCommandService.Object.Handle(command);
        //Assert
        mockAdminCommandService.Verify(x => x.Handle(command), Times.Once);
    }
}