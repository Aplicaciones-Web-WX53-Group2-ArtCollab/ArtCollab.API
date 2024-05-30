
using Infraestructure.Monetization.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Test;

public class UnitTestMonetization
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