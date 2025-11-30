namespace AcademicSystem.Web.DTOs;

public record CreateCourseRequest(
    string Name,
    int Type,
    int TotalHours
);