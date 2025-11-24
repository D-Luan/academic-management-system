using AcademicSystem.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicSystem.Infrastructure.Data.Config;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);

        builder.OwnsOne(t => t.Address, a =>
        {
            a.Property(p => p.Street).HasMaxLength(100).IsRequired();
            a.Property(p => p.City).HasMaxLength(50).IsRequired();
            a.Property(p => p.State).HasMaxLength(2).IsRequired();
            a.Property(p => p.ZipCode).HasMaxLength(20).IsRequired();
        });

        builder.Property(t => t.UserId)
            .IsRequired()
            .HasMaxLength(450);
    }
}
