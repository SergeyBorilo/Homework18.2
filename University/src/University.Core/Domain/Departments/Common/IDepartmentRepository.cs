using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Departments.Common;

public interface IDepartmentRepository
{
    public Task<Department> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Department>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(Department department);

    public void Delete(IReadOnlyCollection<Department> departments);
}
