using Domain.User.Model.Aggregates;
using Domain.User.Model.Commands;
using Domain.User.Model.Queries;
using Domain.User.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Users.REST;
using Presentation.Users.REST.Resources;

namespace Presentation.Test.User;

public class ReaderTestPresentation
{
    [Fact]
    public async Task PostReaderWorking()
    {
        //Arrange
        var mockReaderCommandService = new Mock<IReaderCommandService>();
        var mockReaderQueryService = new Mock<IReaderQueryService>();
        var readerController = new ReaderController(mockReaderCommandService.Object, mockReaderQueryService.Object);
        var command = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
        var reader = new Reader(command);
        var readerResource = new CreateReaderResource(reader.Name, reader.Username, reader.Email, reader.Password, reader.Type, reader.ImgUrl);
        
        //Act
        mockReaderCommandService.Setup(r => r.Handle(command)).ReturnsAsync(reader);
        var result = await readerController.CreateReader(readerResource);
        
        //Assert
        var okResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(201, okResult.StatusCode);
        
        var returnedReader = Assert.IsType<ReaderResource>(okResult.Value);
        Assert.Equal(reader.Username, returnedReader.Username);
        
    }

    [Fact]
    public async Task GetReaderByIdWorking()
    {
        //Arrange
        var mockReaderCommandService = new Mock<IReaderCommandService>();
        var mockReaderQueryService = new Mock<IReaderQueryService>();
        var readerController = new ReaderController(mockReaderCommandService.Object, mockReaderQueryService.Object);
        var command = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
        var reader = new Reader(command);
        var query = new GetReaderByIdQuery(reader.Id);
        var readerResource = new ReaderResource(reader.Id, reader.Username, reader.Type, reader.ImgUrl);
        
        //Act
        mockReaderQueryService.Setup(r => r.Handle(query)).ReturnsAsync(reader);
        var result = await readerController.GetByIdAsync(readerResource.Id);
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        
        var returnedReader = Assert.IsType<ReaderResource>(okResult.Value);
        Assert.Equal(reader.Username, returnedReader.Username);
    }

    [Fact]
    public async Task GetAllReadersWorking()
    {
        //Arrange
        var mockReaderCommandService = new Mock<IReaderCommandService>();
        var mockReaderQueryService = new Mock<IReaderQueryService>();
        var readerController = new ReaderController(mockReaderCommandService.Object, mockReaderQueryService.Object);
        var command = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
        var reader = new Reader(command);
        var query = new GetAllReadersQuery();
        var readerResource = new ReaderResource(reader.Id, reader.Username, reader.Type, reader.ImgUrl);
        
        //Act
        mockReaderQueryService.Setup(r => r.Handle(query)).ReturnsAsync(new List<Reader>(){reader});
        var result = await readerController.GetAllReaders();
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        
        var returnedReaders = Assert.IsType<List<ReaderResource>>(okResult.Value);
        Assert.Equal(reader.Username, readerResource.Username);
    }

    [Fact]
    public async Task UpdateReaderWorking()
    {
        //Arrange
        var mockReaderCommandService = new Mock<IReaderCommandService>();
        var mockReaderQueryService = new Mock<IReaderQueryService>();
        var readerController = new ReaderController(mockReaderCommandService.Object, mockReaderQueryService.Object);
        var updateReaderCommand = new UpdateReaderCommand(1, "John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
        var createReaderCommand = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
        var reader = new Reader(createReaderCommand);
        var readerResource = new UpdateReaderResource( reader.Name, reader.Username, reader.Email, reader.Password, reader.Type, reader.ImgUrl);
        
        //Act
        mockReaderCommandService.Setup(r => r.Handle(updateReaderCommand)).ReturnsAsync(reader);
        var result = await readerController.UpdateReader(updateReaderCommand.Id, readerResource);
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        
        var returnedReader = Assert.IsType<ReaderResource>(okResult.Value);
        Assert.Equal(reader.Username, returnedReader.Username);
    }

    [Fact]
    public async Task DeleteReaderWorking()
    {
        //Arrange
        var mockReaderCommandService = new Mock<IReaderCommandService>();
        var mockReaderQueryService = new Mock<IReaderQueryService>();
        var readerController = new ReaderController(mockReaderCommandService.Object, mockReaderQueryService.Object);
        var command = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
        var reader = new Reader(command);
        var deleteReaderCommand = new DeleteReaderCommand(reader.Id);
        var readerResource = new ReaderResource(reader.Id, reader.Username, reader.Type, reader.ImgUrl);
        
        //Act 
        mockReaderCommandService.Setup(r => r.Handle(deleteReaderCommand)).ReturnsAsync(reader);
        var result = await readerController.DeleteReader(deleteReaderCommand.Id);
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        
        var returnedReader = Assert.IsType<ReaderResource>(okResult.Value);
        Assert.Equal(reader.Username, returnedReader.Username);
    }
}