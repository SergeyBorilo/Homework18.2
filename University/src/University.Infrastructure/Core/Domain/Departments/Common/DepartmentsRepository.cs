using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Departments.Common;

public class DepartmentsRepository(UniversityDbContext dbContext) : IDepartmentRepository
{
    public async Task<Department> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Department>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await dbContext.Departments.Where(d => ids.Contains(d.Id)).ToArrayAsync(cancellationToken);
    }

    public void Add(Department department)
    {
        dbContext.Departments.Add(department);
    }

    public void Delete(IReadOnlyCollection<Department> departments)
    {
        dbContext.Departments.RemoveRange(departments);
    }
}
