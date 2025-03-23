using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;

public interface IFacultyRepository
{
    public Task<Faculty> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Faculty>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(Faculty faculty);

    public void Delete(IReadOnlyCollection<Faculty> faculties);
}
