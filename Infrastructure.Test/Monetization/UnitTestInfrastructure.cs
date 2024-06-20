
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Test.Monetization;

public class UnitTestInfrastructure
{
    
    
    [Fact]
    public void DataBase_IsConfiguring()
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
    

  
    
    

 
}