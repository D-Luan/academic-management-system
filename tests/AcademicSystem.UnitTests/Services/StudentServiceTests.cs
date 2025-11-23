using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Services;
using System.Threading.Tasks;

namespace AcademicSystem.UnitTests.Services;

public class StudentServiceTests
{
    [Fact]
    public async Task RegisterStudentAsync_ShouldCallRepositoryAdd_WhenDataIsValid()
    {
        var mockRepo = new Mock<IRepository<Student>>();
        var mockLogger = new Mock<ILogger<StudentService>>();
        var service = new StudentService(mockRepo.Object, mockLogger.Object);
        var address = new Address("Rua A", "Cidade B", "SP", "12345-678");

        await service.RegisterStudentAsync("user123", "12345", address);

        mockRepo.Verify(r => r.AddAsync(It.IsAny<Student>()), Times.Once);

    }
}
