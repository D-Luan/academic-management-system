using Microsoft.Extensions.Logging;
using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Interfaces;

namespace AcademicSystem.ApplicationCore.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;
    private readonly ILogger<StudentService> _logger;

    public StudentService(IRepository<Student> studentRepository, ILogger<StudentService> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    public async Task<Student> RegisterStudentAsync(string userId, string registrationNumber, Address address)
    {
        _logger.LogInformation($"Starting registration for Registration Number: {registrationNumber}");

        var student = new Student(userId, registrationNumber, address);

        await _studentRepository.AddAsync(student);

        _logger.LogInformation($"Student {student.Id} registered successfully.");

        return student;
    }
}