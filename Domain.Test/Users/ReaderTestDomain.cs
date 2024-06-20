

using Domain.User.Model.Aggregates;
using Domain.User.Model.Commands;
using Domain.User.Model.Queries;
using Domain.User.Repositories;
using Domain.User.Services;
using Moq;

namespace Domain.Test.Users;

public class ReaderTestDomain
{
   [Fact]
   public async Task AddReaderWorking()
   {
      //Arrange
      var command = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
      var reader = new Reader(command);
      var mockReaderCommandService = new Mock<IReaderCommandService>();
      //Act
      mockReaderCommandService.Setup(r => r.Handle(command)).ReturnsAsync(reader);
      var result = await mockReaderCommandService.Object.Handle(command);
      //Assert
      Assert.NotNull(result);
   }

   [Fact]

   public async Task GetAllReadersWorking()
   {
      //Arrange
      var query = new GetAllReadersQuery();
      var mockReaderQueryService = new Mock<IReaderQueryService>();
      //Act
      mockReaderQueryService.Setup(r => r.Handle(query)).ReturnsAsync(new List<Reader>());
      var result = await mockReaderQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(result);
   }

   [Fact]
   public async Task GetReaderByIdWorking()
   {
      //Arrange
      var query = new GetReaderByIdQuery(1);
      var mockReaderQueryService = new Mock<IReaderQueryService>();
      //Act
      mockReaderQueryService.Setup(r => r.Handle(query)).ReturnsAsync(new Reader());
      var result = await mockReaderQueryService.Object.Handle(query);
      //Assert
      Assert.NotNull(result);
   }

   [Fact]
   public void UpdateReaderWorking()
   {
      //Arrange
      var command = new UpdateReaderCommand(1, "John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
      var mockReaderCommandService = new Mock<IReaderCommandService>();
      //Act
      mockReaderCommandService.Setup(r => r.Handle(command)).ReturnsAsync(new Reader());
      var result = mockReaderCommandService.Object.Handle(command);
      //Assert
      Assert.NotNull(result);
   }

   [Fact]
   public void DeleteReaderWorking()
   {
      //Arrange
      var command = new DeleteReaderCommand(1);
      var mockReaderCommandService = new Mock<IReaderCommandService>();
      //Act
      mockReaderCommandService.Setup(r => r.Handle(command)).ReturnsAsync(new Reader());
      var result = mockReaderCommandService.Object.Handle(command);
      //Assert
      Assert.NotNull(result);
   }

   [Fact]
   public async Task BusinessRulesWorking()
   {
      //Arrange
      var newCommand = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
      var repeatCommand = new CreateReaderCommand("John", "Doe", "examplecontact.@gmail.com", "password","writer","exampleimage.jpg");
      var newReader = new Reader(newCommand);
      var repeatReader = new Reader(repeatCommand);
      var mockReaderCommandService = new Mock<IReaderCommandService>();
      var mockReaderRepository = new Mock<IReaderRepository>();
      
      //Act
      mockReaderRepository.Setup(r => r.GetByIdAsync(newReader.Id)).ReturnsAsync(newReader);
      mockReaderCommandService.Setup(r => r.Handle(newCommand)).ReturnsAsync(newReader);
      mockReaderRepository.Setup(r => r.GetByIdAsync(repeatReader.Id)).ThrowsAsync(new Exception("Reader already exists"));
      mockReaderCommandService.Setup(r => r.Handle(repeatCommand)).ThrowsAsync(new Exception("Reader already exists"));
      
      //Assert
      await Assert.ThrowsAsync<Exception>(() => mockReaderCommandService.Object.Handle(repeatCommand));

   }
}