using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Departments.Common;

public class DepartmentMustExistChecker(UniversityDbContext universityDbContext) : IDepartmentMustExistChecker
{
    public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await universityDbContext.Departments.AsNoTracking().AllAsync(d => d.Name != name, cancellationToken);
    }
}
