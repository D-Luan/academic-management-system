using Microsoft.AspNetCore.Mvc;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.Web.DTOs;

namespace AcademicSystem.Web.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterStudentRequest request)
    {
        var address = new Address(
            request.Street,
            request.City,
            request.State,
            request.ZipCode
        );

        var createdStudent = await _studentService.RegisterStudentAsync(
            userId: Guid.NewGuid().ToString(),
            registrationNumber: request.RegistrationNumber,
            address: address
        );

        return CreatedAtAction(
            nameof(Register),
            new { id = createdStudent.Id },
            new { id = createdStudent.Id, registrationNumber = createdStudent.RegistrationNumber }
        );
    }
}
