using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Exceptions;
using Xunit;

namespace AcademicSystem.UnitTests.Entities;

public class CourseTests
{
    [Fact]
    public void Should_ThrowDomainException_When_NameIsInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Course(null!, CourseType.Bachelor, 3200));

        Assert.Throws<DomainException>(() =>
        new Course(null!, CourseType.Bachelor, 3200));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void Should_ThrowDomainException_When_TotalHours_IsInvalid(int invalidHours)
    {
        Assert.Throws<DomainException>(() =>
            new Course("Engineer", CourseType.Bachelor, invalidHours));
    }

    [Fact]
    public void Should_CreateCourse_When_DataIsValid()
    {
        var course = new Course("Computer Science", CourseType.Bachelor, 3600);

        Assert.NotNull(course);
        Assert.Equal("Computer Science", course.Name);
        Assert.Equal(CourseType.Bachelor, course.Type);
    }

    [Fact]
    public void Should_AddSubject_When_Valid()
    {
        var course = new Course("Computer Science", CourseType.Bachelor, 3600);
        var subject = new Subject("Software Engineer", 1, 60);

        course.AddSubject(subject);

        Assert.Single(course.Subjects);
        Assert.Contains(subject, course.Subjects);
    }
}