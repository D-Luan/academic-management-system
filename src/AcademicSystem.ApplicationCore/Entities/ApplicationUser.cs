using Microsoft.AspNetCore.Identity;

namespace AcademicSystem.ApplicationCore.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
