using Infraestructure.Interfaces;
using Infraestructure.Models;
using Moq;

namespace Domain._Test;

public class TemplateUnitTest
{
   [Fact]
    public void Add_ValidTemplate()
    {
        // Arrange
        var template = new Template
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            Genre = string.Empty
        };
        
        var repository = new Mock<IRepository<Template>>();
        repository.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        var repositoryGeneric = new RepositoryGeneric<Template>(repository.Object);
        
        // Act
        repositoryGeneric.Add(template);
        
        // Assert
        repository.Verify(x => x.Add(template), Times.Once);
    }
    
    [Fact]
    public void Add_ValidTemplate_ThrowsArgumentException()
    {
        // Arrange
        var template = new Template
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            Genre = "Genre 1"
        };
        
        var repository = new Mock<IRepository<Template>>();
        repository.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        var repositoryGeneric = new RepositoryGeneric<Template>(repository.Object);
        
        // Act
        // Assert
        Assert.ThrowsAsync<ArgumentException>(() => repositoryGeneric.Add(template));
    }
}