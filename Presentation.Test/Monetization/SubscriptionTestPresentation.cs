using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Monetization.REST;
using Presentation.Monetization.REST.Resources;
namespace Presentation.Test.Monetization;

public class SubscriptionTestPresentation
{
    [Fact]
    public async Task PostSubscriptionWorking()
    {
        //Arrenge
        var mockSubscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var mockSubscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var command = new CreateSubscriptionCommand();
        var subscription = new Subscription(command);
        var controller = new SubscriptionController(mockSubscriptionQueryService.Object, mockSubscriptionCommandService.Object);
        var subscriptionResource = new SubscriptionResource(subscription.Id, subscription.IsActive);
        var createSubscriptionResource = new CreateSubscriptionResource();
        //Act
        mockSubscriptionCommandService.Setup(x => x.Handle(It.IsAny<CreateSubscriptionCommand>())).ReturnsAsync(subscription);
        var result = await controller.CreateSubscription(createSubscriptionResource);
        //Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(201, objectResult.StatusCode);
        var returnedSubscriptionResource = Assert.IsType<SubscriptionResource>(objectResult.Value);
        Assert.Equal(subscriptionResource.Id, returnedSubscriptionResource.Id);
       
    }
    
    [Fact]
    public async Task GetSubscriptionByIdWorking()
    {
        //Arrange
        var mockSubscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var mockSubscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var controller = new SubscriptionController(mockSubscriptionQueryService.Object, mockSubscriptionCommandService.Object);
        var subscription = new Subscription();
        var subscriptionResource = new SubscriptionResource(subscription.Id, subscription.IsActive);
        var query = new GetSubscriptionByIdQuery(1);
        //Act
        mockSubscriptionQueryService.Setup(x => x.Handle(It.IsAny<GetSubscriptionByIdQuery>())).ReturnsAsync(subscription);
        var result = await controller.GetSubscriptionById(query.Id);
        
        //Asert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        var returnedSubscriptionResource = Assert.IsType<SubscriptionResource>(objectResult.Value);
        Assert.Equal(subscriptionResource.Id, returnedSubscriptionResource.Id);
    }

    [Fact]
    public async Task GetAllSubscriptionsWorking()
    {
        //Arrange 
        var mockSubscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var mockSubscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var controller = new SubscriptionController(mockSubscriptionQueryService.Object, mockSubscriptionCommandService.Object);
        var subscription = new Subscription();
        var subscriptionResource = new SubscriptionResource(subscription.Id, subscription.IsActive);
        //Act
        mockSubscriptionQueryService.Setup(x => x.Handle(It.IsAny<GetAllSubscriptionsQuery>())).ReturnsAsync(new List<Subscription>(){subscription});
        var result = await controller.GetAllSubscriptions();
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        var returnedSubscriptionResource = Assert.IsType<List<SubscriptionResource>>(objectResult.Value);
        Assert.Equal(subscriptionResource.Id, returnedSubscriptionResource.First().Id);
    }

    [Fact]
    public async Task DeleteSubscriptionWorking()
    {
        //Arrange
        var mockSubscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var mockSubscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var controller = new SubscriptionController(mockSubscriptionQueryService.Object, mockSubscriptionCommandService.Object);
        var createSubscriptionCommand = new CreateSubscriptionCommand();
        var subscription = new Subscription(createSubscriptionCommand);
        var deleteSubscriptionCommand = new DeleteSubscriptionCommand(subscription.Id);
        var subscriptionResource = new SubscriptionResource(subscription.Id, subscription.IsActive);
        
        //Act
        mockSubscriptionCommandService.Setup(x => x.Handle(It.IsAny<DeleteSubscriptionCommand>())).ReturnsAsync(subscription);
        var result = await controller.DeleteSubscription(deleteSubscriptionCommand.Id);
        
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        var returnedSubscriptionResource = Assert.IsType<SubscriptionResource>(objectResult.Value);
        Assert.Equal(subscriptionResource.Id, returnedSubscriptionResource.Id);
        
    }

    [Fact]
    public async Task UpdateSubscriptionWorking()
    {
        //Arrange
        var mockSubscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var mockSubscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var controller = new SubscriptionController(mockSubscriptionQueryService.Object, mockSubscriptionCommandService.Object);
        var createSubscriptionCommand = new CreateSubscriptionCommand();
        var subscription = new Subscription(createSubscriptionCommand);
        var updateSubscriptionCommand = new UpdateSubscriptionCommand(subscription.Id, true);
        var updateSubscriptionResource = new UpdateSubscriptionResource(updateSubscriptionCommand.IsActive);
        var subscriptionResource = new SubscriptionResource(subscription.Id, subscription.IsActive);
        
        //Act
        mockSubscriptionCommandService.Setup(x => x.Handle(It.IsAny<UpdateSubscriptionCommand>())).ReturnsAsync(subscription);
        var result = await controller.UpdateSubscription(updateSubscriptionCommand.Id, updateSubscriptionResource);
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        var returnedSubscriptionResource = Assert.IsType<SubscriptionResource>(objectResult.Value);
        Assert.Equal(subscriptionResource.Id, returnedSubscriptionResource.Id);
    }
}