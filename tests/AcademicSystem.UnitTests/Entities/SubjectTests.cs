using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Exceptions;
using Xunit;

namespace AcademicSystem.UnitTests.Entities;

public class SubjectTests
{
    [Fact]
    public void Should_ThrowException_When_CourseId_IsInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Subject("Algorithms", 0, 60));
    }

    [Fact]
    public void Should_ThrowException_When_NameIsValid()
    {
        Assert.Throws<DomainException>(() =>
            new Subject("", 1, 60));
    }

    [Fact]
    public void Should_CreateSubject_When_Valid()
    {
        var subject = new Subject("Database", 10, 80);

        Assert.NotNull(subject);
        Assert.Equal("Database", subject.Name);
        Assert.Equal(10, subject.CourseId);
    }
}