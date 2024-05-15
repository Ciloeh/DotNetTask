using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dotnettask.Controllers;
using Dotnettask.DTOs;
using Dotnettask.Services;

public class UserInformationControllerTests
{
    private readonly Mock<IUserInformationServices> _mockService;
    private readonly UserInformationController _controller;

    public UserInformationControllerTests()
    {
        _mockService = new Mock<IUserInformationServices>();
        _controller = new UserInformationController(_mockService.Object);
    }

    [Fact]
    public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
    {
        _mockService.Setup(service => service.GetUserAsync(It.IsAny<string>()))
            .ReturnsAsync((UserInformationDTO)null);

        var result = await _controller.GetUser("nonexistent-id");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetUser_ReturnsUser_WhenUserExists()
    {
        var expectedUser = new UserInformationDTO { Id = "test-id", FirstName = "test-first-name", LastName = "test-last-name", Email = "test-email" };
        _mockService.Setup(service => service.GetUserAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedUser);

        var result = await _controller.GetUser("test-id");

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualUser = Assert.IsType<UserInformationDTO>(okResult.Value);
        Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public async Task CreateUser_ReturnsOk_WhenUserIsCreated()
    {
        var newUser = new UserInformationDTO { Id = "new-id", FirstName = "new-first-name", LastName = "new-last-name", Email = "new-email" };
        _mockService.Setup(service => service.AddUserAsync(It.IsAny<UserInformationDTO>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.CreateUser(newUser);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateUser_ReturnsOk_WhenUserIsUpdated()
    {
        var updatedUser = new UserInformationDTO { Id = "updated-id", FirstName = "updated-first-name", LastName = "updated-last-name", Email = "updated-email" };
        _mockService.Setup(service => service.UpdateUserAsync(It.IsAny<string>(), It.IsAny<UserInformationDTO>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.UpdateUser("updated-id", updatedUser);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteUser_ReturnsOk_WhenUserIsDeleted()
    {
        _mockService.Setup(service => service.DeleteUserAsync(It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeleteUser("deleted-id");

        Assert.IsType<OkResult>(result);
    }
}
