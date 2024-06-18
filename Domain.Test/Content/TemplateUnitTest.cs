using Domain.Content.Interfaces;
using Domain.Repository;
using Infrastructure.Content.Interfaces;
using Infrastructure.Content.Models;
using Moq;

namespace Domain.Test.Content;

public class TemplateUnitTest
{
   [Fact]
    public void AddAsync_ValidTemplate_ReturnsTaskCompletedTask()
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
        var repositoryMock = new Mock<IContentDomain<Template>>();
        
        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync((Template)null);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync((Template)null);
        repositoryMock.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        ContentRepository<Template> repository = new ContentRepository<Template>(repositoryMock.Object, templateDataMock.Object);
        
        // Act
        var result = repository.Add(template);
        
        // Assert
        Assert.Equal(Task.CompletedTask, result);
    }
    
    [Fact]
    public void AddAsync_ValidTemplate_ThrowsException()
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
        var repositoryMock = new Mock<IContentDomain<Template>>();
        
        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync((Template)null);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync((Template)null);
        repositoryMock.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        ContentRepository<Template> repository = new ContentRepository<Template>(repositoryMock.Object, templateDataMock.Object);
        
        // Act
        var exception = repository.Add(template).Exception;
        
        // Assert
        Assert.ThrowsAsync<Exception>(async () => await repository.Add(template));
    }
    
    [Fact]
    public void AddAsync_ReaderWithExistingDescription_ThrowsException()
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
        var repositoryMock = new Mock<IContentDomain<Template>>();

        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync(template2);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync((Template)null);
        repositoryMock.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        ContentRepository<Template> repository = new ContentRepository<Template>(repositoryMock.Object, templateDataMock.Object);

        //Act
        var exception = repository.Add(template).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repository.Add(template));
    } 
    
    [Fact]
    public void AddAsync_ReaderWithExistingCoverImage_ThrowsException()
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
            ImgUrl = "https://example.com/image2.jpg",
            Genre = "Fantasy"
        };

        var templateDataMock = new Mock<ITemplateData<Template>>();
        var repositoryMock = new Mock<IContentDomain<Template>>();

        templateDataMock.Setup(x => x.GetByDescriptionAsync(template.Description)).ReturnsAsync((Template)null);
        templateDataMock.Setup(x => x.GetByCoverImageAsync(template.ImgUrl)).ReturnsAsync(template2);
        repositoryMock.Setup(x => x.Add(template)).Returns(Task.CompletedTask);
        
        ContentRepository<Template> repository = new ContentRepository<Template>(repositoryMock.Object, templateDataMock.Object);

        //Act
        var exception = repository.Add(template).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repository.Add(template));
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
        var repositoryMock = new Mock<IContentDomain<Template>>();

        templateDataMock.Setup(x => x.GetByIdAsync(template.Id)).ReturnsAsync(template);
        templateDataMock.Setup(x => x.Delete(template.Id)).Returns(Task.CompletedTask);
        
        ContentRepository<Template> repository = new ContentRepository<Template>(repositoryMock.Object, templateDataMock.Object);
        
        //Act
        var result=  repository.Delete(template.Id);
        
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
        var repositoryMock = new Mock<IContentDomain<Template>>();

        templateDataMock.Setup(x => x.GetByIdAsync(template.Id)).ReturnsAsync((Template)null);
        
        ContentRepository<Template> repository = new ContentRepository<Template>(repositoryMock.Object, templateDataMock.Object);
        
        //Act
        var result=  repository.Delete(template.Id);
        
        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repository.Delete(template.Id));
    } 

}