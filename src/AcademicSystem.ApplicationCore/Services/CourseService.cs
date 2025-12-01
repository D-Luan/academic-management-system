using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Exceptions;
using AcademicSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace AcademicSystem.ApplicationCore.Services;

public class CourseService : ICourseService
{
    private readonly IRepository<Course> _courseRepository;
    private readonly ILogger<CourseService> _logger;

    public CourseService(IRepository<Course> courseRepository, ILogger<CourseService> logger)
    {
        _courseRepository = courseRepository;
        _logger = logger;
    }

    public async Task<Course> CreateCourseAsync(string name, CourseType type, int totalHours)
    {
        _logger.LogInformation($"Creating new course: {name}");

        var course = new Course(name, type, totalHours);

        await _courseRepository.AddAsync(course);

        _logger.LogInformation($"Course {course.Id} created successfully.");

        return course;
    }

    public async Task<Subject> AddSubjectAsync(int courseId, string name, int workload)
    {
        _logger.LogInformation($"Adding subject '{name}' to Course ID {courseId}");

        var course = await _courseRepository.GetByIdAsync(courseId);

        if (course == null)
        {
            throw new DomainException($"Course with ID {courseId} not found.");
        }

        var subject = new Subject(name, courseId, workload);

        course.AddSubject(subject);

        await _courseRepository.UpdateAsync(course);

        _logger.LogInformation("Subject added successfully.");

        return subject;
    }
}