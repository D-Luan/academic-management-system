using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Exceptions;
using System;

namespace AcademicSystem.ApplicationCore.Entities;

public class Enrollment : BaseEntity
{
    public int StudentId { get; private set; }
    public int CourseId { get; private set; }
    public DateTime EnrollmentDate { get; private set; }
    public int Semester { get; private set; }
    public EnrollmentStatus Status { get; private set; }

    protected Enrollment() {}

    public Enrollment(int studentId, int courseId)
    {
        if (studentId <= 0)
        {
            throw new DomainException("Invalid Student ID.");
        }

        if (courseId <= 0)
        {
            throw new DomainException("Invalid Course ID.");
        }
        
        this.StudentId = studentId;
        this.CourseId = courseId;

        EnrollmentDate = DateTime.UtcNow;
        Semester = 1;
        Status = EnrollmentStatus.Active;
    }
}