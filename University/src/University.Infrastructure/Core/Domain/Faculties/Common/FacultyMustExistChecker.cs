using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Faculties.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties.Common;

public class FacultyMustExistChecker(UniversityDbContext universityDbContext) : IFacultyMustExistChecker
{
    public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await universityDbContext.Groups.AsNoTracking().AllAsync(f => f.Name != name, cancellationToken);
    }
}
