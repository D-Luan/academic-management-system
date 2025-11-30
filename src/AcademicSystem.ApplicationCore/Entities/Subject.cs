using AcademicSystem.ApplicationCore.Exceptions;

namespace AcademicSystem.ApplicationCore.Entities;

public class Subject : BaseEntity
{
    public string Name { get; private set; } = null!;
    public int CourseId { get; private set; }
    public int Workload { get; private set; }

    protected Subject() { }

    public Subject(string name, int courseId, int workload)
    {
        if (courseId <= 0)
        {
            throw new DomainException("Invalid Course ID.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Name is required.");
        }
        
        this.Name = name;
        this.CourseId = courseId;
        this.Workload = workload;
    }
}