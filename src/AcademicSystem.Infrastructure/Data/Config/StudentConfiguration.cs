using AcademicSystem.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicSystem.Infrastructure.Data.Config;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.OwnsOne(s => s.Address, a =>
        {
            a.Property(a => a.Street).HasMaxLength(100).IsRequired();
            a.Property(a => a.City).HasMaxLength(50).IsRequired();
            a.Property(a => a.State).HasMaxLength(2).IsRequired();
            a.Property(a => a.ZipCode).HasMaxLength(20).IsRequired();

        });

        builder.Property(s => s.RegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);
    }
}
