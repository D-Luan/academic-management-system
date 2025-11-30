using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Exceptions;

namespace AcademicSystem.ApplicationCore.Entities;

public class Course : BaseEntity
{
    public string Name { get; private set; } = null!;
    public CourseType Type { get; private set; }
    public int TotalHours { get; private set; }

    protected Course() { }

    public Course(string name, CourseType type, int totalHours)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Course name is required.");
        }

        if (totalHours <= 0)
        {
            throw new DomainException("Total hours must be greater than zero.");
        }

        this.Name = name;
        this.Type = type;
        this.TotalHours = totalHours;
    }
}
