using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AcademicSystem.UnitTests.Services;

public class CourseServiceTests
{
    [Fact]
    public async Task CreateCourseAsync_ShouldCallRepository_WhenDataIsValid()
    {
        var mockRepo = new Mock<IRepository<Course>>();
        var mockLogger = new Mock<ILogger<CourseService>>();
        var service = new CourseService(mockRepo.Object, mockLogger.Object);

        var result = await service.CreateCourseAsync("Software Engineer", CourseType.Bachelor, 4000);

        mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Course>()), Times.Once);

        Assert.NotNull(result);
        Assert.Equal("Software Engineer", result.Name);
    }
}