
using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Monetization.REST;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Test.Monetization;

public class CommisionTestPresentation
{
    [Fact]
    public async Task PostCommisionWorking()
    {
        //Arrange
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        var command = new CreateCommisionCommand(100,"ExampleContent");
        var commision = new Commision(command);
        var controller = new CommisionController(mockCommisionCommandService.Object, mockCommisionQueryService.Object);
        var commisionResource = new CommisionResource(commision.Id, commision.Amount, commision.Content);
        var createCommisionResource = new CreateCommisionResource(command.Amount, command.Content);
        
        //Act
        mockCommisionCommandService.Setup(x => x.Handle(command)).ReturnsAsync(commision);
        var result = await controller.Post(createCommisionResource);
        //Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(201, objectResult.StatusCode);
        
        var returnedCommisionResource = Assert.IsType<CommisionResource>(objectResult.Value);
        Assert.Equal(commisionResource.Id, returnedCommisionResource.Id);
        
    }
    
    [Fact]
    public async Task GetCommisionByIdWorking()
    {
        //Arrange
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        var command = new CreateCommisionCommand(100, "ExampleContent");
        var commision = new Commision(command);
        var controller = new CommisionController(mockCommisionCommandService.Object, mockCommisionQueryService.Object);
        var query = new GetCommisionByIdQuery(commision.Id);
        var commisionResource = new CommisionResource(commision.Id, commision.Amount, commision.Content);
        
        //Act
        mockCommisionQueryService.Setup(x => x.Handle(query)).ReturnsAsync(commision);
        var result = await controller.GetById(commision.Id);
        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjectResult.StatusCode);
        
        var returnedCommisionResource = Assert.IsType<CommisionResource>(okObjectResult.Value);
        Assert.Equal(commisionResource.Id, returnedCommisionResource.Id);
    }

    [Fact]
    public async Task GetAllCommisionsWorking()
    {
        //Arrange
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        var command = new CreateCommisionCommand(100, "ExampleContent");
        var commision = new Commision(command);
        var controller = new CommisionController(mockCommisionCommandService.Object, mockCommisionQueryService.Object);
        var query = new GetAllCommisionsQuery();
        var commisionResource = new CommisionResource(commision.Id, commision.Amount, commision.Content);
        
        //Act
        mockCommisionQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Commision>(){commision});
        var result = await controller.GetAll();
        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjectResult.StatusCode);
        
        var returnedCommisionResources = Assert.IsType<List<CommisionResource>>(okObjectResult.Value);
        Assert.Equal(commisionResource.Id, returnedCommisionResources.First().Id);
    }
    
    [Fact]
    public async Task UpdateCommisionWorking()
    {
        //Arrange
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        var command = new CreateCommisionCommand(100, "ExampleContent");
        var commision = new Commision(command);
        var controller = new CommisionController(mockCommisionCommandService.Object, mockCommisionQueryService.Object);
        var updateCommand = new UpdateCommisionCommand(commision.Id, 200, "UpdatedContent");
        var commisionResource = new CommisionResource(commision.Id, commision.Amount, commision.Content);
        
        //Act
        mockCommisionCommandService.Setup(x => x.Handle(updateCommand)).ReturnsAsync(commision);
        var result = await controller.Update(commision.Id, new UpdateCommisionResource(updateCommand.Amount, updateCommand.Content));
        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjectResult.StatusCode);
        
        var returnedCommisionResource = Assert.IsType<CommisionResource>(okObjectResult.Value);
        Assert.Equal(commisionResource.Id, returnedCommisionResource.Id);
    }
    
    [Fact]
    public async Task DeleteCommisionWorking()
    {
        //Arrange
        var mockCommisionCommandService = new Mock<ICommisionCommandService>();
        var mockCommisionQueryService = new Mock<ICommisionQueryService>();
        var command = new CreateCommisionCommand(100, "ExampleContent");
        var commision = new Commision(command);
        var controller = new CommisionController(mockCommisionCommandService.Object, mockCommisionQueryService.Object);
        var query = new DeleteCommisionCommand(commision.Id);
        
        //Act
        mockCommisionCommandService.Setup(x => x.Handle(query)).ReturnsAsync(commision);
        var result = await controller.Delete(commision.Id);
        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjectResult.StatusCode);
        
        var returnedCommisionResource = Assert.IsType<CommisionResource>(okObjectResult.Value);
        Assert.Equal(commision.Id, returnedCommisionResource.Id);
    }
}