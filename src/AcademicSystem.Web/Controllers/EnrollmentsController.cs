using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.Web.DTOs;

namespace AcademicSystem.Web.Controllers;

[ApiController]
[Route("api/enrollments")]
[Authorize]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;
    
    public EnrollmentsController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Enroll([FromBody] EnrollStudentRequest request)
    {
        var enrollment = await _enrollmentService.EnrollStudentAsync(
            request.StudentId,
            request.CourseId
        );

        return StatusCode(StatusCodes.Status201Created, new { id = enrollment.Id });
    }
}