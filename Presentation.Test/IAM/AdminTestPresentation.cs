using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Queries;
using Domain.IAM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.IAM.REST;
using Presentation.IAM.REST.Resources;

namespace Presentation.Test.IAM;

public class AdminTestPresentation
{
    [Fact]
    public async Task GetAdminByIdWorking()
    {
        //Arrange
        var mockAdminQueryService = new Mock<IAdminQueryService>();
        var controller = new AdminController(mockAdminQueryService.Object);
        var admin = new Admin("John Doe", "Password Hash");
        var adminResource = new AdminResource(admin.Id, admin.Username);
        var query = new GetAdminByIdQuery(admin.Id);

        //Act
        mockAdminQueryService.Setup(x => x.Handle(query)).ReturnsAsync(admin);
        var result = await controller.GetAdminById(admin.Id);

        //Arrange
        var okObjResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjResult.StatusCode);
        var returnedAdminResource = Assert.IsType<AdminResource>(okObjResult.Value);
        Assert.Equal(adminResource.Id, returnedAdminResource.Id);
    }

    [Fact]
    public async Task GetAllAdminsWorking()
    {
        //Arrange
        var mockAdminQueryService = new Mock<IAdminQueryService>();
        var controller = new AdminController(mockAdminQueryService.Object);
        var admin = new Admin("John Doe", "Password Hash");
        var adminResource = new AdminResource(admin.Id, admin.Username);
        var query = new GetAllAdminsQuery();
        
        //Act
        mockAdminQueryService.Setup(x => x.Handle(query)).ReturnsAsync(new List<Admin> {admin});
        var result = await controller.GetAllUsers();
        
        //Arrange
        var okObjResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okObjResult.StatusCode);
        var returnedAdminResource = Assert.IsType<List<AdminResource>>(okObjResult.Value);
        Assert.Equal(adminResource.Id, returnedAdminResource[0].Id);

    }
}