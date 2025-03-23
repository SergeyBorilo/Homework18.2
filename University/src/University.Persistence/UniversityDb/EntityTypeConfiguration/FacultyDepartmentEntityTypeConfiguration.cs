using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Faculties.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfiguration;

public class FacultyDepartmentEntityTypeConfiguration : IEntityTypeConfiguration<FacultyDepartment>
{
    public void Configure(EntityTypeBuilder<FacultyDepartment> builder)
    {
        builder.HasKey(fd => new { fd.FacultyId, fd.DepartmentId });
    }
}
