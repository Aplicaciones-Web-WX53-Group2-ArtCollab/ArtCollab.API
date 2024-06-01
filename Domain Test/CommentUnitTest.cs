using System.Net;
using Domain;
using Infraestructure;
using Infraestructure.Models;
using Moq;

namespace _2.Domain_Test;

public class CommentUnitTest
{
    [Fact]
    public void SaveAsync_ValidComment_ReturnValidId()
    {
        //Arrage
        Comment comment = new Comment()
        {
            Name = "Reader 1",
            Image = "http://www.image.com/image.jpg",
            Content = "Content",
            Rank = "TOP",
            Likes = 0,
            Dislikes = 0,
            Date = DateTime.Now,
        };
        Comment comment2 = null;
        
        List<Comment> comments = new List<Comment>();
        
        var commentDataMock = new Mock<ICommentData>();
        commentDataMock.Setup(t => t.getCommentByNameAsync(comment.Name)).ReturnsAsync(comment2);
        commentDataMock.Setup(t => t.getAllCommentAsync()).ReturnsAsync(comments);
        commentDataMock.Setup(t => t.SaveCommentAsync(comment)).ReturnsAsync(1);
        
        CommentDomain commentDomain = new CommentDomain(commentDataMock.Object);
        
        //Act
        var result = commentDomain.SaveCommentAsync(comment);
        
        //Assert
        Assert.Equal(1, result.Id);
        
    }
    
    [Fact]
    public void SaveAsync_DuplicateCommentName_ReturnValidId()
    {
        //Arrange
        Comment comment = new Comment()
        {
            Name = "Reader 1",
            Image = "http://www.image.com/image.jpg",
            Content = "Content",
            Rank = "TOP",
            Likes = 0,
            Dislikes = 0,
            Date = DateTime.Now,
        };
        
        Comment comment2 = new Comment()
        {
            Name = "Reader 1",
            Image = "http://www.image.com/image.jpg",
            Content = "Content",
            Rank = "TOP",
            Likes = 0,
            Dislikes = 0,
            Date = DateTime.Now,
        };
        
        List<Comment> comments = new List<Comment>();
        comments.Add(comment2);
        
        var commentDataMock = new Mock<ICommentData>();
        commentDataMock.Setup(t => t.getCommentByNameAsync(comment.Name)).ReturnsAsync(comment2);
        commentDataMock.Setup(t => t.getAllCommentAsync()).ReturnsAsync(comments);
        
        CommentDomain commentDomain = new CommentDomain(commentDataMock.Object);
        
        //Act
        var result = commentDomain.SaveCommentAsync(comment);
        
        //Assert
        Assert.ThrowsAsync<Exception>(async () => await commentDomain.SaveCommentAsync(comment));
    }
    
    [Fact]
    public void DeleteAsync_ValidId_ReturnTrue()
    {
        Comment comment = new Comment()
        {
            Id = 1,
            Name = "Reader 1",
            Image = "http://www.image.com/image.jpg",
            Content = "Content",
            Rank = "TOP",
            Likes = 0,
            Dislikes = 0,
            Date = DateTime.Now,
        };
        
        var commentDataMock = new Mock<ICommentData>(); 
        commentDataMock.Setup(t => t.getByIdCommentAsync(comment.Id)).ReturnsAsync(comment);
        commentDataMock.Setup(t => t.DeleteCommentAsync(comment.Id)).ReturnsAsync(true);
        
        CommentDomain commentDomain = new CommentDomain(commentDataMock.Object);
        
        //Act
        var result = commentDomain.DeleteCommentAsync(comment.Id);
        
        //Assert
        Assert.Equal(true, result.Result);
    }
    [Fact]
    public void UpdateAsync_ValidComment_ReturnTrue()
    {
        Comment comment = new Comment()
        {
            Id = 0,
            Name = "Reader 1",
            Image = "http://www.image.com/image.jpg",
            Content = "Content",
            Rank = "TOP",
            Likes = 0,
            Dislikes = 0,
            Date = DateTime.Now,
        };
        
        var commentDataMock = new Mock<ICommentData>();
        commentDataMock.Setup(t => t.getByIdCommentAsync(comment.Id)).ReturnsAsync((Comment)null);
        
        CommentDomain commentDomain = new CommentDomain(commentDataMock.Object);
        
        //Act
        var result = commentDomain.DeleteCommentAsync(comment.Id);
        
        //Assert
        Assert.ThrowsAsync<Exception>(async () => commentDomain.DeleteCommentAsync(comment.Id));
    }
}