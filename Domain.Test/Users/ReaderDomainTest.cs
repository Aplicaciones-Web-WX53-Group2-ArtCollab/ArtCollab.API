using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.Model;
using Moq;

namespace Domain.Test.Users;

public class ReaderDomainTest
{
    [Fact]
    public void AddAsync_ValidReader_ReturnsValidId()
    {
        //Arrange
        Reader reader = new Reader()
        {
            Name = "Reader 1",
            UserName = "reader1",
            Email = "user@example.com",
            Password = "password",
            Type = "reader",
            ImgUrl = "https://example.com/image.jpg",
        };
        Reader? reader2 = null;
        Reader? reader3 = null;

        var readerDataMock = new Mock<IReaderData>();
        var repositoryMock = new Mock<IRepository<Reader>>();

        readerDataMock.Setup(t => t.GetByUserNameAsync(reader.UserName)).ReturnsAsync(reader2);
        readerDataMock.Setup(t => t.GetByEmailAsync(reader.Email)).ReturnsAsync(reader3);
        repositoryMock.Setup(t => t.AddAsync(reader)).ReturnsAsync(1);

        RepositoryGeneric<Reader> repositoryGeneric = new RepositoryGeneric<Reader>(repositoryMock.Object, readerDataMock.Object);

        //Act
        var result = repositoryGeneric.AddAsync(reader);

        //Assert
        Assert.Equal(1, result.Result);
    }

    [Fact]
    public void AddAsync_ReaderWithExistingUserName_ThrowsException()
    {
        //Arrange
        Reader reader = new Reader()
        {
            Name = "Reader 1",
            UserName = "reader1",
            Email = "user@example.com",
            Password = "password",
            Type = "reader",
            ImgUrl = "https://example.com/image.jpg",
        };
        Reader reader2 = new Reader()
        {
            Name = "Reader 2",
            UserName = "reader1",
            Email = "user2@example.com",
            Password = "password",
            Type = "reader",
            ImgUrl = "https://example.com/image2.jpg",
        };
        Reader? reader3 = null;

        var readerDataMock = new Mock<IReaderData>();
        var repositoryMock = new Mock<IRepository<Reader>>();

        readerDataMock.Setup(t => t.GetByUserNameAsync(reader.UserName)).ReturnsAsync(reader2);
        readerDataMock.Setup(t => t.GetByEmailAsync(reader.Email)).ReturnsAsync(reader3);
        repositoryMock.Setup(t => t.AddAsync(reader)).ReturnsAsync(1);

        RepositoryGeneric<Reader> repositoryGeneric = new RepositoryGeneric<Reader>(repositoryMock.Object, readerDataMock.Object);

        //Act
        var exception = repositoryGeneric.AddAsync(reader).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.AddAsync(reader));
    }

    [Fact]
    public void AddAsync_ReaderWithExistingEmail_ThrowsException()
    {
        //Arrange
        Reader reader = new Reader()
        {
            Name = "Reader 1",
            UserName = "reader1",
            Email = "user@example.com",
            Password = "password",
            Type = "reader",
            ImgUrl = "https://example.com/image.jpg",
        };
        Reader? reader2 = null;
        Reader reader3 = new Reader()
        {
            Name = "Reader 2",
            UserName = "reader2",
            Email = "user@example.com",
            Password = "password",
            Type = "reader",
            ImgUrl = "https://example.com/image2.jpg",
        };

        var readerDataMock = new Mock<IReaderData>();
        var repositoryMock = new Mock<IRepository<Reader>>();

        readerDataMock.Setup(t => t.GetByUserNameAsync(reader.UserName)).ReturnsAsync(reader2);
        readerDataMock.Setup(t => t.GetByEmailAsync(reader.Email)).ReturnsAsync(reader3);
        repositoryMock.Setup(t => t.AddAsync(reader)).ReturnsAsync(1);

        RepositoryGeneric<Reader> repositoryGeneric =
            new RepositoryGeneric<Reader>(repositoryMock.Object, readerDataMock.Object);

        //Act
        var exception = repositoryGeneric.AddAsync(reader).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.AddAsync(reader));
    }

    [Fact]
    public void AddAsync_ReaderWithInvalidType_ThrowsException()
    {
        //Arrange
        Reader reader = new Reader()
        {
            Name = "Reader 1",
            UserName = "reader1",
            Email = "user@example.com",
            Password = "password",
            Type = "invalid",
            ImgUrl = "https://example.com/image.jpg",
        };
        Reader? reader2 = null;
        Reader? reader3 = null;

        var readerDataMock = new Mock<IReaderData>();
        var repositoryMock = new Mock<IRepository<Reader>>();

        readerDataMock.Setup(t => t.GetByUserNameAsync(reader.UserName)).ReturnsAsync(reader2);
        readerDataMock.Setup(t => t.GetByEmailAsync(reader.Email)).ReturnsAsync(reader3);
        repositoryMock.Setup(t => t.AddAsync(reader)).ReturnsAsync(1);

        RepositoryGeneric<Reader> repositoryGeneric =
            new RepositoryGeneric<Reader>(repositoryMock.Object, readerDataMock.Object);

        //Act
        var exception = repositoryGeneric.AddAsync(reader).Exception;

        //Assert
        Assert.ThrowsAsync<Exception>(async () => await repositoryGeneric.AddAsync(reader));
    }
}