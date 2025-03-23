using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Faculties.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfiguration;

public class FacultyEntityTypeConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(f => f.Name)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);

        builder.Metadata
            .FindNavigation(nameof(Faculty.Departments))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(f => f.Departments)
            .WithOne()
            .HasForeignKey(f => f.FacultyId)
            .IsRequired();
    }
}
