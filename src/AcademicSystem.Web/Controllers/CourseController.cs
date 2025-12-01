using AcademicSystem.ApplicationCore.Enums;
using AcademicSystem.ApplicationCore.Exceptions;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.Web.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcademicSystem.Web.Controllers;

[ApiController]
[Route("api/courses")]
[Authorize]
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

    [HttpPost("{courseId}/subjects")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddSubject(int courseId, [FromBody] CreateSubjectRequest request)
    {
        try
        {
            var createdSubject = await _courseService.AddSubjectAsync(
                courseId,
                request.Name,
                request.Workload
            );

            return StatusCode(StatusCodes.Status201Created, new { id = createdSubject.Id, name = createdSubject.Name });
        }
        catch (DomainException ex) when (ex.Message.Contains("not found"))
        {
            return NotFound(ex.Message);
        }
    }
}