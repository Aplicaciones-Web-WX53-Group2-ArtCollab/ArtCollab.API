

using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;
using Moq;

namespace Domain.Test.Monetization;

public class SubscriptionTestDomain
{
    [Fact]
    public async Task AddSubscriptionWorking()
    {
        //Arrange
        var command = new CreateSubscriptionCommand();
        var subscription = new Subscription(command);
        var subscriptionCommandService = new Mock<ISubscriptionCommandService>();
        //Act
        subscriptionCommandService.Setup(x => x.Handle(command)).ReturnsAsync(subscription);
        
        //Assert
        var result = await subscriptionCommandService.Object.Handle(command);
        Assert.NotNull(result);
    }
    
    [Fact]
    public void UpdateSubscriptionWorking()
    {
        //Arrange
        var command = new UpdateSubscriptionCommand(1, true);
        var subscriptionRepository = new Mock<ISubscriptionRepository>();
        var subscription = new Subscription();
        //Act
        subscriptionRepository.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(subscription);
        //Assert
        subscriptionRepository.Setup(x => x.Update(It.IsAny<Subscription>()));
    }
    
    
    [Fact]
    public async Task GetSubscriptionByIdWorking()
    {
        //Arrange
        var query = new GetSubscriptionByIdQuery(1);
        var subscriptionQueryService = new Mock<ISubscriptionQueryService>();
        
        //Act
        subscriptionQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new Subscription());
        var subscription = await subscriptionQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(subscription);
    }

    [Fact]
    public void DeleteSubscriptionWorking()
    {
        //Arrange
        var command = new DeleteSubscriptionCommand(1);
        var subscriptionRepository = new Mock<ISubscriptionRepository>();
        var commandService = new Mock<ISubscriptionCommandService>();
        //Act
        subscriptionRepository.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(new Subscription());
        //Assert
        commandService.Setup(x => x.Handle(command));
    }
    
    [Fact]
    public async Task GetAllSubscriptionsWorking()
    {
        //Arrange
        var query = new GetAllSubscriptionsQuery();
        var subscriptionQueryService = new Mock<ISubscriptionQueryService>();
        
        //Act
        subscriptionQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Subscription>());
        var subscriptions = await subscriptionQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(subscriptions);
    }
    
    [Fact]
    public async Task GetSubscriptionsByIdWorking()
    {
        //Arrange
        var query = new GetSubscriptionByIdQuery(1);
        var subscriptionQueryService = new Mock<ISubscriptionQueryService>();
        //Act
        subscriptionQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new  Subscription());
        var subscription = await subscriptionQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(subscription);

    }
}