using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfiguration;

public class DepartamentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(d => d.Name)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany<FacultyDepartment>()
            .WithOne(d => d.Department)
            .HasForeignKey(d => d.DepartmentId)
            .IsRequired();
    }
}
