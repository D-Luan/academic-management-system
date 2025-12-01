using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Exceptions;
using Xunit;

namespace AcademicSystem.UnitTests.Entities;

public class EnrollmentTestes
{
    [Fact]
    public void Should_ThrowException_When_StudentOrCourse_IsInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Enrollment(0, 10));

        Assert.Throws<DomainException>(() =>
            new Enrollment(10, 0));
    }

    [Fact]
    public void Should_StartWith_ActiveStatus_And_SemesterOne()
    {
        var enrollment = new Enrollment(studentId: 5, courseId: 10);

        Assert.Equal(5, enrollment.StudentId);
        Assert.Equal(10, enrollment.CourseId);
        Assert.Equal(1, enrollment.Semester);
        Assert.Equal(EnrollmentStatus.Active, enrollment.Status);
        Assert.True(enrollment.EnrollmentDate <= DateTime.UtcNow);
    }
}