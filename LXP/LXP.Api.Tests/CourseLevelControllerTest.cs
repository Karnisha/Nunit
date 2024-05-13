using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LXP.Api.Controllers;

[TestFixture]
public class CourseLevelControllerTests
{
    private Mock<ICourseLevelServices> _courseLevelServicesMock;
    private CourseLevelController _controller;

    [Test]
    public async Task GetAllCourseLevel_WhenAccessedByValid_ReturnsOk()
    {
        // Arrange
        _courseLevelServicesMock = new Mock<ICourseLevelServices>();
        _controller = new CourseLevelController(_courseLevelServicesMock.Object);
        string accessedBy = "validUser";
        _courseLevelServicesMock.Setup(x => x.GetAllCourseLevel(accessedBy))
            .ReturnsAsync(new List<string> { "Beginner", "Intermediate", "Advanced" });

        // Act
        var result = await _controller.GetAllCourseLevel(accessedBy);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        Assert.IsNotNull(okResult.Value);
        Assert.IsInstanceOf<List<string>>(okResult.Value);
        Assert.AreEqual(3, (okResult.Value as List<string>).Count);
    }

    [Test]
    public async Task GetAllCourseLevel_WhenAccessedByInvalid_ReturnsBadRequest()
    {
        // Arrange
        _courseLevelServicesMock = new Mock<ICourseLevelServices>();
        _controller = new CourseLevelController(_courseLevelServicesMock.Object);
        string accessedBy = "invalidUser";
        _courseLevelServicesMock.Setup(x => x.GetAllCourseLevel(accessedBy))
            .ReturnsAsync(new List<string>());

        // Act
        var result = await _controller.GetAllCourseLevel(accessedBy);

        // Assert
        Assert.IsInstanceOf<BadRequestResult>(result);
        var badRequestResult = result as BadRequestResult;
        Assert.IsNotNull(badRequestResult);
        Assert.AreEqual(400, badRequestResult.StatusCode);
    }
}