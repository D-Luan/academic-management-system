namespace AcademicSystem.Web.DTOs;

public record LoginRequest(
    string Email,
    string Password
);