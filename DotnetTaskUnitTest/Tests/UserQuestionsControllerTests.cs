using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dotnettask.Controllers;
using Dotnettask.DTOs;
using Dotnettask.Services;

public class UserQuestionsControllerTests
{
    private readonly Mock<IUserQuestionServices> _mockService;
    private readonly UserQuestionsController _controller;

    public UserQuestionsControllerTests()
    {
        _mockService = new Mock<IUserQuestionServices>();
        _controller = new UserQuestionsController(_mockService.Object);
    }

    [Fact]
    public async Task GetUserQuestion_ReturnsNotFound_WhenQuestionDoesNotExist()
    {
        _mockService.Setup(service => service.GetUserQuestionAsync(It.IsAny<string>()))
            .ReturnsAsync((UserQuestionDto)null);

        var result = await _controller.GetUserQuestion("nonexistent-id");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetUserQuestion_ReturnsQuestion_WhenQuestionExists()
    {
        var expectedQuestion = new UserQuestionDto { Id = "test-id", Question = "test-question" };
        _mockService.Setup(service => service.GetUserQuestionAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedQuestion);

        var result = await _controller.GetUserQuestion("test-id");

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualQuestion = Assert.IsType<UserQuestionDto>(okResult.Value);
        Assert.Equal(expectedQuestion, actualQuestion);
    }

    [Fact]
    public async Task CreateUserQuestion_ReturnsOk_WhenQuestionIsCreated()
    {
        var newUserQuestion = new UserQuestionDto { Id = "new-id", Question = "new-question" };
        _mockService.Setup(service => service.AddUserQuestionAsync(It.IsAny<UserQuestionDto>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.CreateUserQuestion(newUserQuestion);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateUserQuestion_ReturnsOk_WhenQuestionIsUpdated()
    {
        var updatedUserQuestion = new UserQuestionDto { Id = "updated-id", Question = "updated-question" };
        _mockService.Setup(service => service.UpdateUserQuestionAsync(It.IsAny<string>(), It.IsAny<UserQuestionDto>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.UpdateUserQuestion("updated-id", updatedUserQuestion);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteUserQuestion_ReturnsOk_WhenQuestionIsDeleted()
    {
        _mockService.Setup(service => service.DeleteUserQuestionAsync(It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeleteUserQuestion("deleted-id");

        Assert.IsType<OkResult>(result);
    }
}
