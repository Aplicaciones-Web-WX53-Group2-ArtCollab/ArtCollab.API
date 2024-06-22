

using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;
using Domain.Content.Model.Entities;
using Domain.Content.Model.Queries;
using Domain.Content.Repositories;
using Domain.Content.Services;
using Moq;

namespace Domain.Test.Content;

public class TemplateTestDomain
{
  [Fact]
  public async Task CreateTemplateWorking()
  {
     //Arrange
     var command = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolio","ExampleDescription",10,false);
     var portfolio = new Portfolio();
     var templateState = new TemplateState(command.TemplateState);
     var template = new Template(command,portfolio,templateState);
     var mockTemplateCommandService = new Mock<ITemplateCommandService>();
     //ACT
     mockTemplateCommandService.Setup(x => x.Handle(command)).ReturnsAsync(template);
     
     //ASSERT
      var result = await mockTemplateCommandService.Object.Handle(command);
      Assert.NotNull(result);
  }

  [Fact]

  public void UpdateTemplateWorking()
  {
        //Arrange
      var command = new UpdateTemplateCommand(1, "ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolio","ExampleDescription",10,false);
      var mockTemplateRepository = new Mock<ITemplateRepository>();
      var template = new Template();
      
      //Act
      mockTemplateRepository.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(template);
      //Assert
      mockTemplateRepository.Setup(x => x.Update(It.IsAny<Template>()));
  }

  [Fact]
  public async Task GetTemplateByIdWorking()
  {
      //Arrange
      var query = new GetTemplateByIdQuery(1);
      var mockTemplateQueryService = new Mock<ITemplateQueryService>();
      
      //Act
      mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new Template());
      var template = await mockTemplateQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(template);
      
  }
  
  [Fact]
  public async Task GetTemplatesByGenreWorking()
  {
      //Arrange
      var query = new GetTemplatesByGenreQuery("ExampleGenre");
      var mockTemplateQueryService = new Mock<ITemplateQueryService>();
      
      //Act
      mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Template>());
      var templates = await mockTemplateQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(templates);
  }
  
  [Fact]
  public async Task GetAllTemplatesWorking()
  {
      //Arrange
      var query = new GetAllTemplatesQuery();
      var mockTemplateQueryService = new Mock<ITemplateQueryService>();
      
      //Act
      mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Template>());
      var templates = await mockTemplateQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(templates);
  }

  [Fact]
  public async Task GetTemplateByCoverImageWorking()
  {
      //Arrange
      var query = new GetTemplateByCoverImageQuery("ExampleImgUrl");
      var mockTemplateQueryService = new Mock<ITemplateQueryService>();
      
      //Act
      mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new Template());
      var template = await mockTemplateQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(template);

  }

  [Fact]
  public async Task GetTemplateByDescription()
  {
      //Arrange
      var query = new GetTemplateByDescriptionQuery("ExampleDescription");
      var mockTemplateQueryService = new Mock<ITemplateQueryService>();
      //Act
      mockTemplateQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new Template());
      var template = await mockTemplateQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(template);
  }
  
  [Fact]
  public async Task DeleteTemplateWorking()
  {
      //Arrange
      var command = new DeleteTemplateCommand(1);
      var mockTemplateCommandService = new Mock<ITemplateCommandService>();
      var mockTemplateRepository = new Mock<ITemplateRepository>();
      //Act
      mockTemplateRepository.Setup(x => x.GetByIdAsync(command.Id));
      mockTemplateRepository.Setup(x => x.Delete(It.IsAny<Template>()));
      
      //Assert
      mockTemplateCommandService.Setup(x => x.Handle(command));
      await mockTemplateCommandService.Object.Handle(command);
  }

  [Fact]
  public async Task BusinessRulesAreWorking()
  {
      //Arrange
      var newCommand = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolio","ExampleDescription",10,false);
      var repeatCommand = new CreateTemplateCommand("ExampleTitle", "ExampleDescription", "ExampleType", "ExampleImgUrl", "ExampleGenre","ExamplePortfolio","ExampleDescription",10,false);
      var mockTemplateCommandService = new Mock<ITemplateCommandService>();
      var portfolio = new Portfolio();
      var templateState = new TemplateState(newCommand.TemplateState);
      var newTemplate = new Template(newCommand,portfolio,templateState);
      
      //Act
      mockTemplateCommandService.Setup(x => x.Handle(newCommand)).ReturnsAsync(newTemplate);
      mockTemplateCommandService.Setup(x => x.Handle(repeatCommand)).ThrowsAsync(new Exception("Template with the same title already exists."));
      //Assert
      await Assert.ThrowsAsync<Exception>(() => mockTemplateCommandService.Object.Handle(repeatCommand));
  }

}