
using Infraestructure.Monetization.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Test;

public class UnitTestMonetization
{
    
    
    [Fact]
    public void DataBase_IsCreating()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseInMemoryDatabase("Test");
        // Act
        using var context = new AppDbContext(optionsBuilder.Options);
        // Assert
        Assert.NotNull(context);
    }

    [Fact]
    public void Tables_AreCreating()
    {
        
        //Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseInMemoryDatabase("Test");
        //Act
        using var context = new AppDbContext(optionsBuilder.Options);  
        var entities = context.Model.GetEntityTypes();
        //Assert
        Assert.NotNull(entities);
    }

    [Fact]

    public async Task Transactions_AreExecuting()
    {
        //Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseInMemoryDatabase("Test");
        //Act
        var context = new AppDbContext(optionsBuilder.Options);
        var strategy = context.Database.CreateExecutionStrategy();
        IDbContextTransaction transaction = null;
        await strategy.ExecuteAsync(async () =>
        {
            transaction = await context.Database.BeginTransactionAsync();
        });
        //Assert
        Assert.NotNull(transaction);
    }
    
    

 
}