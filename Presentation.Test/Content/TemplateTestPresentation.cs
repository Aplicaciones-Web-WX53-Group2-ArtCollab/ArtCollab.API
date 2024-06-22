using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;
using Domain.Content.Model.Entities;
using Domain.Content.Model.Queries;
using Domain.Content.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Content.REST;
using Presentation.Content.REST.Resources;

namespace Presentation.Test.Content;

public class TemplateTestPresentation
{
    [Fact]
    public async Task PostTemplateWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolioTitle", "ExamplePortfolioDescription",1,false);
        var templateResource = new CreateTemplateResource(command.Title, command.Description, command.Type,
            command.ImgUrl, command.Genre, command.PortfolioTitle, command.PortfolioDescription, command.PortfolioQuantity, command.TemplateState);
    
        var expectedTemplate = new Template(command, new Portfolio(), new TemplateState(command.TemplateState));
        mockTemplateCommandService.Setup(x => x.Handle(command)).ReturnsAsync(expectedTemplate);
    
        //Act
        var result = await controller.CreateTemplate(templateResource);
    
        //Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(201, objectResult.StatusCode);
    
        var returnedTemplateResource = Assert.IsType<TemplateResource>(objectResult.Value);
        Assert.Equal(templateResource.TemplateState, returnedTemplateResource.TemplateState);
    }

    [Fact]
    public async Task DeleteTemplateWorking()
    {
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var deleteTemplateResource = new DeleteTemplateResource(1);
        var deleteCommand = new DeleteTemplateCommand(deleteTemplateResource.Id);
        var createCommand = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolioTitle", "ExamplePortfolioDescription",1,false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(createCommand.TemplateState);
        var template = new Template(createCommand,portfolio,templateState);
        var templateResource = new DeleteTemplateResource(template.Id);
        
        //Act
        mockTemplateCommandService.Setup(x => x.Handle(deleteCommand)).ReturnsAsync(template);
        var result = await controller.DeleteTemplate(deleteTemplateResource.Id);
        
        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjectResult.StatusCode);
        
        var returnedTemplateResource = Assert.IsType<TemplateResource>(okObjectResult.Value);
        Assert.Equal(templateResource.Id, returnedTemplateResource.Id);
    }

    [Fact]
    public async Task UpdateTemplateWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var createCommand = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolioTitle", "ExamplePortfolioDescription",1,false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(createCommand.TemplateState);
        var template = new Template(createCommand,portfolio,templateState);
        var templateResource = new UpdateTemplateResource(template.Title, template.Description, template.Type, template.ImgUrl, template.Genre,template.Portfolio.Title,template.Portfolio.Description,template.Portfolio.Quantity,template.TemplateState.Flag);
        var updateCommand = new UpdateTemplateCommand(template.Id, template.Title, template.Description, template.Type, template.ImgUrl, template.Genre,template.Portfolio.Title,template.Portfolio.Description,template.Portfolio.Quantity,template.TemplateState.Flag);
        var updateTemplateResource = new UpdateTemplateResource(template.Title, template.Description, template.Type, template.ImgUrl, template.Genre,template.Portfolio.Title,template.Portfolio.Description,template.Portfolio.Quantity,template.TemplateState.Flag);
        
        //Act
        mockTemplateCommandService.Setup(x => x.Handle(
            It.Is<UpdateTemplateCommand>( c => c.Id == 
                updateCommand.Id && c.Title == updateCommand.Title && 
                c.Description == updateCommand.Description && 
                c.Type == updateCommand.Type && 
                c.ImgUrl == updateCommand.ImgUrl && 
                c.Genre == updateCommand.Genre))).ReturnsAsync(template);
        var result = await controller.UpdateTemplate(updateCommand.Id, updateTemplateResource);
        
        //Assert 
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplateResource = Assert.IsType<TemplateResource>(objectResult.Value);
        Assert.Equal(templateResource.Title, returnedTemplateResource.Title);
    }

    [Fact]
    public async Task GetTemplateByIdWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolio","ExampleDescription",10,false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(command.TemplateState);
        var template = new Template(command,portfolio,templateState);
        var query = new GetTemplateByIdQuery(template.Id);
        var templateResource = new TemplateResource(template.Id, template.Title, template.Description, template.Type, template.ImgUrl, template.Genre,template.TemplateState.Flag);
        
        //Act
        mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(template);
        var result = await controller.GetTemplateById(template.Id);
        
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplateResource = Assert.IsType<TemplateResource>(objectResult.Value);
        Assert.Equal(templateResource.Title, returnedTemplateResource.Title);
    }

    [Fact]
    public async Task GetAllTemplatesWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl",
            "ExampleGenre", "ExamplePortfolioTitle", "ExamplePortfolioDescription",1,false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(command.TemplateState);
        var template = new Template(command,portfolio,templateState);
        var query = new GetAllTemplatesQuery();
        var templateResource = new TemplateResource(template.Id, template.Title, template.Description, template.Type, template.ImgUrl, template.Genre,template.TemplateState.Flag);
        
        //Act 
        mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Template> {template});
        var result = await controller.GetAllTemplates();
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplateResources = Assert.IsType<List<TemplateResource>>(objectResult.Value);
        Assert.Equal(templateResource.Title, returnedTemplateResources.First().Title);
    }
    
    [Fact]
    public async Task GetTemplatesByGenreWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", 
            "ExampleImgUrl", "ExampleGenre","ExamplePortfolioTitle", "ExamplePortfolioDescription",1,false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(command.TemplateState);
        var template = new Template(command,portfolio,templateState);
        var query = new GetTemplatesByGenreQuery(template.Genre);
        var templateResource = new TemplateResource(template.Id, template.Title, template.Description, template.Type, template.ImgUrl, template.Genre,template.TemplateState.Flag);
        
        //Act
        mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Template> {template});
        var result = await controller.GetTemplatesByGenre(template.Genre);
        
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplateResources = Assert.IsType<List<TemplateResource>>(objectResult.Value);
        Assert.Equal(templateResource.Title, returnedTemplateResources.First().Title);
    }

    [Fact]
    public async Task GetTemplateByDescriptionWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", 
            "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolioTitle", "ExamplePortfolioDescription",1, false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(command.TemplateState);
        var template = new Template(command,portfolio, templateState);
        var query = new GetTemplateByDescriptionQuery(template.Description);
        var templateResource = new TemplateResource(template.Id, template.Title, template.Description, template.Type, template.ImgUrl, template.Genre, template.TemplateState.Flag);
        
        //Act
        mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(template);
        var result = await controller.GetTemplateByDescription(template.Description);
        
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplateResource = Assert.IsType<TemplateResource>(objectResult.Value);
        Assert.Equal(templateResource.Title, returnedTemplateResource.Title);
    }

    [Fact]
    public async Task GetTemplateByCoverImgWorking()
    {
        //Arrange
        var mockTemplateCommandService = new Mock<ITemplateCommandService>();
        var mockTemplateQueryService = new Mock<ITemplateQueryService>();
        var controller = new TemplateController(mockTemplateCommandService.Object, mockTemplateQueryService.Object);
        var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", 
            "ExampleImgUrl", "ExampleGenre","ExamplePortfolioTitle", "ExamplePortfolioDescription",1, false);
        var portfolio = new Portfolio();
        var templateState = new TemplateState(command.TemplateState);
        var template = new Template(command,portfolio,templateState);
        var query = new GetTemplateByCoverImageQuery(template.ImgUrl);
        var templateResource = new TemplateResource(template.Id, template.Title, template.Description, template.Type, template.ImgUrl, template.Genre, template.TemplateState.Flag);
        
        //Act
        mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(template);
        var result = await controller.GetTemplateByCoverImage(template.ImgUrl);
        
        //Assert
        var objectResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplateResource = Assert.IsType<TemplateResource>(objectResult.Value);
        Assert.Equal(templateResource.Title, returnedTemplateResource.Title);

    }
}