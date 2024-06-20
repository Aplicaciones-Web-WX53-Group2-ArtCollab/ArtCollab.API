using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Commands;
using Domain.Collaboration.Model.Queries;
using Domain.Collaboration.Services;
using Moq;

namespace Domain.Test.Collaboration;

public class CommentTestDomain
{
    [Fact]
    public async Task AddCommentWorking()
    {
        //Arrange
        var command = new CreateCommentCommand("Example content");
        var comment = new Comment(command);
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        //Act
        mockCommentCommandService.Setup(x => x.Handle(command)).ReturnsAsync(comment);
        var result = await mockCommentCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
        
    }
    
    [Fact]
    public void UpdateCommentWorking()
    {
        //Arrange
        var command = new UpdateCommentCommand(1, "Example content");
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        //Act
        mockCommentCommandService.Setup(x => x.Handle(command));
        var result = mockCommentCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetCommentByIdWorking()
    {
        //Arrange
        var query = new GetCommentByIdQuery(1);
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        //Act
        mockCommentQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new Comment());
        var comment = await mockCommentQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(comment);
    }

    [Fact]
    public void DeleteCommentWorking()
    {
        //Arrange
        var command = new DeleteCommentCommand(1);
        var mockCommentCommandService = new Mock<ICommentCommandService>();
        //Act
        mockCommentCommandService.Setup(x => x.Handle(command));
        var result = mockCommentCommandService.Object.Handle(command);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllComments()
    {
        //Arrange
        var query = new GetAllCommentsQuery();
        var mockCommentQueryService = new Mock<ICommentQueryService>();
        //Act
        mockCommentQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Comment>());
        var comments = await mockCommentQueryService.Object.Handle(query);
        //Assert
        Assert.NotNull(comments);
    }
}