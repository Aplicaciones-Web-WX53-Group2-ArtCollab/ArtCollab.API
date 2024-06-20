

namespace Domain.Test.Monetization;

public class UnitTestDomain
{
    /*[Fact]
    public void AddAsync_IsWorking()
    {
        // Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
        // Act
        var result = mockRepository.Object.AddAsync(new Subscription());
        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetByIdAsync_IsWorking()
    {
        // Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription?>>();
        // Act
        var result = mockRepository.Object.GetByIdAsync(1);
        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAllAsync_IsWorking()
    {
        //Arrange 
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
        //Act
        var result = mockRepository.Object.GetAllAsync();
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Update_IsWorking()
    {
        //Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
        //Act
        var result = mockRepository.Object.Update(new Subscription());
        //Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void Delete_IsWorking()
    {
        //Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
        //Act
        var result = mockRepository.Object.Delete(1);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void BussinesRules_AreWorking()
    {
        //Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Commision>>();
        Commision commisionWithContentEmpty = new Commision()
        {
            Content = " ",
            Amount = 1000
        };
        Commision commisionWithNegativeAmount = new Commision()
        {
            Content = "For someone",
            Amount = -1
        };
            
        //Act
        var result = mockRepository.Object.AddAsync(commisionWithNegativeAmount);
        //Assert
        Assert.ThrowsAsync<Exception>(async ()  => await mockRepository.Object.AddAsync(commisionWithNegativeAmount));
      
    }

    [Fact]
    public void Subscription_Updating_Validate()
    {
        //Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
        var mockObserver = new Mock<Observer>();

        mockObserver.Setup(o => o.Update()).Returns(new HttpResponseMessage(HttpStatusCode.Accepted));
        //Act
        var request = mockRepository.Object.Update(new Subscription());
        var responseObserver = mockObserver.Object.Update();
        //Assert
        Assert.NotNull(request);
        Assert.Equal(HttpStatusCode.Accepted, responseObserver.StatusCode);
    }*/
}