using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Students.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfiguration;

internal class StudentsEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.FirstName)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.MiddleName)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.PasportSerialNumber)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);
    }
}
