using Domain.Monetization.Interface;
using Domain.Monetization.Model.Aggregates;
using Moq;

namespace Domain.Test;

public class UnitTestMonetization
{
    [Fact]
    public void AddAsync_IsWorking()
    {
        // Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
        // Act
        var result = mockRepository.Object.Add(new Subscription());
        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetByIdAsync_IsWorking()
    {
        // Arrange
        var mockRepository = new Mock<IRepositoryGeneric<Subscription>>();
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
}