using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dotnettask.Controllers;
using Dotnettask.DTOs;
using Dotnettask.Services;

public class ChoiceQuestionControllerTests
{
    private readonly Mock<IChoiceQuestionService> _mockService;
    private readonly ChoiceQuestionController _controller;

    public ChoiceQuestionControllerTests()
    {
        _mockService = new Mock<IChoiceQuestionService>();
        _controller = new ChoiceQuestionController(_mockService.Object);
    }

    [Fact]
    public async Task GetChoiceQuestion_ReturnsNotFound_WhenQuestionDoesNotExist()
    {
        _mockService.Setup(service => service.GetChoiceQuestionAsync(It.IsAny<string>()))
            .ReturnsAsync((ChoiceQuestionDto)null);

        var result = await _controller.GetChoiceQuestion("nonexistent-id");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetChoiceQuestion_ReturnsChoiceQuestion_WhenQuestionExists()
    {
        var expectedQuestion = new ChoiceQuestionDto { Id = "test-id", Choice = "test-choice", dateadded = DateTime.Now };
        _mockService.Setup(service => service.GetChoiceQuestionAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedQuestion);

        var result = await _controller.GetChoiceQuestion("test-id");

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualQuestion = Assert.IsType<ChoiceQuestionDto>(okResult.Value);
        Assert.Equal(expectedQuestion, actualQuestion);
    }

    [Fact]
    public async Task CreateChoiceQuestion_ReturnsOk_WhenQuestionIsCreated()
    {
        var newQuestion = new ChoiceQuestionDto { Id = "new-id", Choice = "new-choice", dateadded = DateTime.Now };
        _mockService.Setup(service => service.AddChoiceQuestionAsync(It.IsAny<ChoiceQuestionDto>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.CreateChoiceQuestion(newQuestion);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateChoiceQuestion_ReturnsOk_WhenQuestionIsUpdated()
    {
        var updatedQuestion = new ChoiceQuestionDto { Id = "updated-id", Choice = "updated-choice", dateadded = DateTime.Now };
        _mockService.Setup(service => service.UpdateChoiceQuestionAsync(It.IsAny<string>(), It.IsAny<ChoiceQuestionDto>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.UpdateChoiceQuestion("updated-id", updatedQuestion);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteChoiceQuestion_ReturnsOk_WhenQuestionIsDeleted()
    {
        _mockService.Setup(service => service.DeleteChoiceQuestionAsync(It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeleteChoiceQuestion("deleted-id");

        Assert.IsType<OkResult>(result);
    }
}
