using AcademicSystem.ApplicationCore.Entities;
using System.Runtime.CompilerServices;

namespace AcademicSystem.ApplicationCore.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
