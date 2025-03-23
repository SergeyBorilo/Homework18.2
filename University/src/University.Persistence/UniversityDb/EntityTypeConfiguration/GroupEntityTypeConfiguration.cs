using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Groups.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfiguration;

public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Name)
            .ValueGeneratedNever()
            .IsRequired()
            .HasMaxLength(50);
    }
}
