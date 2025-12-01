using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Exceptions;
using Microsoft.Extensions.Logging;

namespace AcademicSystem.ApplicationCore.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IRepository<Enrollment> _enrollmentRepository;
    private readonly ILogger<EnrollmentService> _logger;

    public EnrollmentService(IRepository<Enrollment> enrollmentRepository, ILogger<EnrollmentService> logger)
    {
        _enrollmentRepository = enrollmentRepository;
        _logger = logger;
    }

    public async Task<Enrollment> EnrollStudentAsync(int studentId, int courseId)
    {
        _logger.LogInformation($"Starting enrollment for Student {studentId} in Course {courseId}");

        var enrollment = new Enrollment(studentId, courseId);

        await _enrollmentRepository.AddAsync(enrollment);

        _logger.LogInformation($"Enrollment {enrollment.Id} created successfully.");

        return enrollment;
    }
}