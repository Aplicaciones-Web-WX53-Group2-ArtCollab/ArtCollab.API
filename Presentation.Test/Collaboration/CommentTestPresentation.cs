using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Commands;
using Domain.Collaboration.Model.Queries;
using Domain.Collaboration.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Collaboration.REST;
using Presentation.Collaboration.REST.Resources;

namespace Presentation.Test.Collaboration;

public class CommentTestPresentation
{
    [Fact]
    public async Task CreateCommentWorking()
    {
        // Arrange
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        var controller = new CommentController(mockCommentCommandService.Object, mockCommentQueryService.Object);
        var createCommentResource = new CreateCommentResource("Example Content");
        var command = new CreateCommentCommand(createCommentResource.Content);
        var comment = new Comment(command);
        var commentResource = new CommentResource(comment.Id,comment.Content);

        // Act
        mockCommentCommandService
            .Setup(x => x.Handle(It.Is<CreateCommentCommand>(c => c.Content == command.Content)))
            .ReturnsAsync(comment);
        var result = await controller.PostComment(createCommentResource);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(201, objectResult.StatusCode);

        var returnedCommentResource = Assert.IsType<CommentResource>(objectResult.Value);
        Assert.Equal(commentResource.Content, returnedCommentResource.Content);
    }

    [Fact]
    public async Task DeleteCommentWorking()
    {
        // Arrange
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        var controller = new CommentController(mockCommentCommandService.Object, mockCommentQueryService.Object);
        var deleteCommentResource = new DeleteCommentResource(1);
        var deleteCommand = new DeleteCommentCommand(deleteCommentResource.Id);
        var createCommand = new CreateCommentCommand("Example Content");
        var comment = new Comment(createCommand);
        var commentResource = new CommentResource(comment.Id, comment.Content);

        // Act
        mockCommentCommandService
            .Setup(x => x.Handle(It.Is<DeleteCommentCommand>(c => c.Id == deleteCommand.Id)))
            .ReturnsAsync(comment);
        var result = await controller.DeleteComment(deleteCommentResource.Id);

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var returnedCommentResource = Assert.IsType<CommentResource>(okObjectResult.Value);
        Assert.Equal(commentResource.Content, returnedCommentResource.Content);
    }
    
    [Fact]
    public async Task UpdateCommentWorking()
    {
        // Arrange
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        var controller = new CommentController(mockCommentCommandService.Object, mockCommentQueryService.Object);
        var updateCommentResource = new UpdateCommentResource("Example Content");
        var updateCommand = new UpdateCommentCommand(1,updateCommentResource.Content);
        var createCommand = new CreateCommentCommand("Example Content");
        var comment = new Comment(createCommand);
        var commentResource = new CommentResource(comment.Id, comment.Content);

        // Act
        mockCommentCommandService
            .Setup(x => x.Handle(It.Is<UpdateCommentCommand>(c => c.Id == updateCommand.Id && c.Comment == updateCommand.Comment)))
            .ReturnsAsync(comment);
        var result = await controller.PutComment(1, updateCommentResource);

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var returnedCommentResource = Assert.IsType<CommentResource>(okObjectResult.Value);
        Assert.Equal(commentResource.Content, returnedCommentResource.Content);
    }

    [Fact]
    public async Task GetAllCommentsWorking()
    {
        //Arrange
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        var controller = new CommentController(mockCommentCommandService.Object, mockCommentQueryService.Object);
        var query = new GetAllCommentsQuery();
        var comment = new Comment(new CreateCommentCommand("Example Content"));
        var commentResource = new CommentResource(comment.Id, comment.Content);

        //Act
        mockCommentQueryService
            .Setup(x => x.Handle(It.Is<GetAllCommentsQuery>(q => q == query)))
            .ReturnsAsync(new List<Comment> { comment });
        var result = await controller.GetAllComments();

        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var returnedCommentResources = Assert.IsType<List<CommentResource>>(okObjectResult.Value);
        Assert.Equal(commentResource.Content, returnedCommentResources.First().Content);
    }

    [Fact]
    public async Task GetCommentByIdWorking()
    {
        //Arrange
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        var controller = new CommentController(mockCommentCommandService.Object, mockCommentQueryService.Object);
        var query = new GetCommentByIdQuery(1);
        var comment = new Comment(new CreateCommentCommand("Example Content"));
        var commentResource = new CommentResource(comment.Id, comment.Content);
        
        //Act
        mockCommentQueryService
            .Setup(x => x.Handle(It.Is<GetCommentByIdQuery>(q => q.Id == query.Id)))
            .ReturnsAsync(comment);
        var result = await controller.GetCommentById(1);
        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var returnedCommentResource = Assert.IsType<CommentResource>(okObjectResult.Value);
        Assert.Equal(commentResource.Content, returnedCommentResource.Content);
    }
}