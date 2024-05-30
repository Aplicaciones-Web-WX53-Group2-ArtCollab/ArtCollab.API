using Infraestructure.Content.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Models;
using Moq;

namespace Domain._Test;

public class TemplateUnitTest
{
   [Fact]
    public void Add_ValidTemplate_ReturnsTaskCompletedTask()
    {
        // Arrange
        Template template = new Template()
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            ImgUrl = "https://example.com/image.jpg",
            Genre = string.Empty
        };

        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repository = new Mock<IRepository<Template>>();
        
        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync((Template)null);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync((Template)null);
        repository.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        RepositoryGeneric<Template> repositoryGeneric = new RepositoryGeneric<Template>(repository.Object, templateDataMock.Object);
        
        // Act
        var result = repositoryGeneric.Add(template);
        
        // Assert
        Assert.Equal(Task.CompletedTask, result);
    }
    
    [Fact]
    public void Add_ValidTemplate_ThrowsException()
    {
        // Arrange
        Template template = new Template()
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            ImgUrl = "https://example.com/image.jpg",
            Genre = "Romance"
        };
        
        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repository = new Mock<IRepository<Template>>();
        
        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync((Template)null);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync((Template)null);
        repository.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        RepositoryGeneric<Template> repositoryGeneric = new RepositoryGeneric<Template>(repository.Object, templateDataMock.Object);
        
        // Act
        var exception = repositoryGeneric.Add(template).Exception;
        
        // Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.Add(template));
    }
    
    [Fact]
    public void Add_ReaderWithExistingDescription_ThrowsException()
    {
        //Arrange
        Template template = new Template()
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            ImgUrl = "https://example.com/image.jpg",
            Genre = "Romance"
        };
        Template template2 = new Template()
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            ImgUrl = "https://example.com/image2.jpg",
            Genre = "Fantasy"
        };

        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repository = new Mock<IRepository<Template>>();

        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync(template2);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync((Template)null);
        repository.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        RepositoryGeneric<Template> repositoryGeneric = new RepositoryGeneric<Template>(repository.Object, templateDataMock.Object);

        //Act
        var exception = repositoryGeneric.Add(template).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.Add(template));
    } 
    
    [Fact]
    public void Add_ReaderWithExistingCoverImage_ThrowsException()
    {
        //Arrange
        Template template = new Template()
        {
            Title = "Template 1",
            Description = "Description 1",
            Type = "Illustration",
            ImgUrl = "https://example.com/image.jpg",
            Genre = "Romance"
        };
        Template template2 = new Template()
        {
            Title = "Template 1",
            Description = "Description 2",
            Type = "Illustration",
            ImgUrl = "https://example.com/image.jpg",
            Genre = "Fantasy"
        };

        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repository = new Mock<IRepository<Template>>();

        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync((Template)null);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync(template2);
        repository.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        RepositoryGeneric<Template> repositoryGeneric = new RepositoryGeneric<Template>(repository.Object, templateDataMock.Object);

        //Act
        var exception = repositoryGeneric.Add(template).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.Add(template));
    }
    
    [Fact]
    public void DeleteAsync_ValidId_ReturnsTaskCompletedTask()
    {
        //Arrage
        Template template = new Template()
        {
            Id = 1,
            Title = "Template 1",
            Description = "Description 1",
            Type = "Book",
            ImgUrl = "https://example.com/image.jpg",
            Genre = "Romance"
        };
        
        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repository = new Mock<IRepository<Template>>();

        repository.Setup(x => x.GetByIdAsync(template.Id)).ReturnsAsync(template);
        repository.Setup(x => x.Delete(template.Id)).Returns(Task.CompletedTask);
        
        RepositoryGeneric<Template> repositoryGeneric = new RepositoryGeneric<Template>(repository.Object, templateDataMock.Object);
        
        //Act
        var result=  repositoryGeneric.Delete(template.Id);
        
        //Assert
        Assert.Equal(Task.CompletedTask, result);
    } 
    
    [Fact]
    public void DeleteAsync_InvalidId_ThrowsException()
    {
        //Arrage
        Template template = new Template()
        {
            Id = 0,
            Title = "Template 1",
            Description = "Description 1",
            Type = "Book",
            ImgUrl = "https://example.com/image.jpg",
            Genre = "Romance"
        };
        
        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repository = new Mock<IRepository<Template>>();

        repository.Setup(x => x.GetByIdAsync(template.Id)).ReturnsAsync((Template)null);
        
        RepositoryGeneric<Template> repositoryGeneric = new RepositoryGeneric<Template>(repository.Object, templateDataMock.Object);
        
        //Act
        var result=  repositoryGeneric.Delete(template.Id);
        
        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.Delete(template.Id));
    } 

}