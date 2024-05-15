using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dotnettask.Controllers;
using Dotnettask.DTOs;
using Dotnettask.Services;

public class ProgramInformationControllerTests
{
    private readonly Mock<IProgramService> _mockService;
    private readonly ProgramInformationController _controller;

    public ProgramInformationControllerTests()
    {
        _mockService = new Mock<IProgramService>();
        _controller = new ProgramInformationController(_mockService.Object);
    }

    [Fact]
    public async Task GetProgram_ReturnsNotFound_WhenProgramDoesNotExist()
    {
        _mockService.Setup(service => service.GetProgramAsync(It.IsAny<string>()))
            .ReturnsAsync((ProgramInformationDTO)null);

        var result = await _controller.GetProgram("nonexistent-id");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetProgram_ReturnsProgram_WhenProgramExists()
    {
        var expectedProgram = new ProgramInformationDTO { Id = "test-id", ProgramId = "test-program-id", ProgramTitle = "test-title", ProgramDescription = "test-description" };
        _mockService.Setup(service => service.GetProgramAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedProgram);

        var result = await _controller.GetProgram("test-id");

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualProgram = Assert.IsType<ProgramInformationDTO>(okResult.Value);
        Assert.Equal(expectedProgram, actualProgram);
    }

    [Fact]
    public async Task CreateProgram_ReturnsOk_WhenProgramIsCreated()
    {
        var newProgram = new ProgramInformationDTO { Id = "new-id", ProgramId = "new-program-id", ProgramTitle = "new-title", ProgramDescription = "new-description" };
        _mockService.Setup(service => service.AddProgramAsync(It.IsAny<ProgramInformationDTO>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.CreateProgram(newProgram);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateProgram_ReturnsOk_WhenProgramIsUpdated()
    {
        var updatedProgram = new ProgramInformationDTO { Id = "updated-id", ProgramId = "updated-program-id", ProgramTitle = "updated-title", ProgramDescription = "updated-description" };
        _mockService.Setup(service => service.UpdateProgramAsync(It.IsAny<string>(), It.IsAny<ProgramInformationDTO>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.UpdateProgram("updated-id", updatedProgram);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteProgram_ReturnsOk_WhenProgramIsDeleted()
    {
        _mockService.Setup(service => service.DeleteProgramAsync(It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var result = await _controller.DeleteProgram("deleted-id");

        Assert.IsType<OkResult>(result);
    }
}
