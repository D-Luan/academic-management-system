using System.Threading.Tasks;
using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Enums;

namespace AcademicSystem.ApplicationCore.Interfaces;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(string name, CourseType type, int totalHours);
}