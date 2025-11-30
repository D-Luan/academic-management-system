using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.Web.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AcademicSystem.Web.Controllers;

[ApiController]
[Route("api/courses")]
[Authorize(AuthenticationSchemes = "Identity.Bearer")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
    {
        var courseType = (CourseType)request.Type;

        var createdCourse = await _courseService.CreateCourseAsync(
            request.Name,
            courseType,
            request.TotalHours
        );

        return CreatedAtAction(
            nameof(Create),
            new { id = createdCourse.Id },
            new { id = createdCourse.Id, name = createdCourse.Name }
        );
    }
}