using Microsoft.AspNetCore.Mvc;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.Web.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AcademicSystem.Web.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentController(IStudentService studentService, UserManager<ApplicationUser> userManager)
    {
        _studentService = studentService;
        _userManager = userManager;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterStudentRequest request)
    {
        var newUser = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FullName = request.FullName
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        try
        {
            var address = new Address(
                request.Street, request.City, request.State, request.ZipCode
            );

            var createdStudent = await _studentService.RegisterStudentAsync(
                userId: newUser.Id,
                registrationNumber: request.RegistrationNumber,
                address: address
            );

            return CreatedAtAction(
                nameof(Register),
                new { id = createdStudent.Id },
                new { id = createdStudent.Id, registrationNumber = createdStudent.RegistrationNumber }
            );
        }
        catch (Exception)
        {
            await _userManager.DeleteAsync(newUser);
            throw;
        }
    }
}