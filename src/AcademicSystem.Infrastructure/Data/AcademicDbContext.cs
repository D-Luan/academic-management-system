using AcademicSystem.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace AcademicSystem.Infrastructure.Data;

public class AcademicDbContext : IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
{
    public AcademicDbContext(DbContextOptions<AcademicDbContext> options) 
        : base(options)
    { 
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
