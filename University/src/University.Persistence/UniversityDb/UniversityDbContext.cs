using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Students.Models;
using Group = University.Core.Domain.Groups.Models.Group;

namespace University.Persistence.UniversityDb;

public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options)
{
    public static readonly string StudentsDbSchema = "students";

    public static readonly string StudentsMigrationHistory = "__StudentsMigrationHistory";

    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<FacultyDepartment> FacultyDepartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(StudentsDbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
    }
}
