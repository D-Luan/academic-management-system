using System.Threading.Tasks;
using AcademicSystem.ApplicationCore.Entities;

namespace AcademicSystem.ApplicationCore.Interfaces;

public interface IStudentService
{
    Task<Student> RegisterStudentAsync(string userId, string registrationNumber, Address address);
}
