using AcademicSystem.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademicSystem.Infrastructure.Data;

public class AcademicDbContext : IdentityDbContext<ApplicationUser> 
{
    public AcademicDbContext(DbContextOptions<AcademicDbContext> options) 
        : base(options)
    { 
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
