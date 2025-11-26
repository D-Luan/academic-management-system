namespace AcademicSystem.Web.DTOs;

public record RegisterStudentRequest(
    string Email,
    string Password,
    string FullName,
    string RegistrationNumber,
    string Street,
    string City,
    string State,
    string ZipCode
);