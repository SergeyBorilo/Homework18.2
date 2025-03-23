using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Persistence.UniversityDb;

namespace University.Persistence;

public static class UniversityDbContextRegistration
{
    public static void AddUniversityDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UniversityDb");

        services.AddDbContext<UniversityDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        UniversityDbContext.StudentsMigrationHistory,
                        UniversityDbContext.StudentsDbSchema);
                });
        });
    }
}
