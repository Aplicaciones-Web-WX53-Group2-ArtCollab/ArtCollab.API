

using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;
using Moq;

namespace Domain.Test.Monetization;

public class CommisionTestDomain
{
    [Fact]
    public async Task GetCommisionByIdWorking()
    {
        //Arrange
        var query = new GetCommisionByIdQuery(1);
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        //Act
        mockCommisionQueryService.Setup(c => c.Handle(query)).ReturnsAsync(new Commision());
        var result = await mockCommisionQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllCommisionsWorking()
    {
        //Arrange
        var query = new GetAllCommisionsQuery();
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        //Act
        mockCommisionQueryService.Setup(c => c.Handle(query)).ReturnsAsync(new List<Commision>());
        var result = await mockCommisionQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task AddCommisionWorking()
    {
        //Arrange
        var command = new CreateCommisionCommand(500, "Content example");
        var commision = new Commision(command);
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        //Act
        mockCommisionCommandService.Setup(c => c.Handle(command)).ReturnsAsync(commision);
        var result = await mockCommisionCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void UpdateCommisionWorking()
    {
        //Arrange
        var command = new UpdateCommisionCommand(1, 500, "Content example");
        var mockCommisionRepository = new Mock<ICommisionRepository>();
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        //Act
        mockCommisionRepository.Setup(c => c.GetByIdAsync(command.Id)).ReturnsAsync(new Commision());
        var result = mockCommisionCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void DeleteCommisionWorking()
    {
        //Arrange
        var command = new DeleteCommisionCommand(1);
        var mockCommisionRepository = new Mock<ICommisionRepository>();
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        //Act
        mockCommisionRepository.Setup(c => c.GetByIdAsync(command.Id)).ReturnsAsync(new Commision());
        var result = mockCommisionCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task BusinessRulesAreWorking()
    {
        //Arrange
        var command = new CreateCommisionCommand(-1, "Bad example request");
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        //Act
        mockCommisionCommandService.Setup(c => c.Handle(command)).ThrowsAsync(new Exception("Amount must be greater than 0"));
        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await mockCommisionCommandService.Object.Handle(command));
    }
}