using System.Threading.Tasks;
using AcademicSystem.ApplicationCore.Entities;

namespace AcademicSystem.ApplicationCore.Interfaces;

public interface IEnrollmentService
{
    Task<Enrollment> EnrollStudentAsync(int studentId, int courseId);
}