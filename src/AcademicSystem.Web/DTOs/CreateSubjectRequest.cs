namespace AcademicSystem.Web.DTOs;

public record CreateSubjectRequest(
    string Name,
    int Workload
);