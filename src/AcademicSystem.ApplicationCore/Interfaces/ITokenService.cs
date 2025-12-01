using AcademicSystem.ApplicationCore.Entities;

namespace AcademicSystem.ApplicationCore.Interfaces;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user);
}