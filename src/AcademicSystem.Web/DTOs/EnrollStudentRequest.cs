namespace AcademicSystem.Web.DTOs;

public record EnrollStudentRequest(
    int StudentId,
    int CourseId
);