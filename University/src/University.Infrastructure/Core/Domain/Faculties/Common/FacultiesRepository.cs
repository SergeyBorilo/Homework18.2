using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties.Common;

public class FacultiesRepository(UniversityDbContext dbContext) : IFacultyRepository
{
    public async Task<Faculty> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Faculties.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Faculty>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await dbContext.Faculties.Where(f => ids.Contains(f.Id)).ToArrayAsync(cancellationToken);
    }

    public void Add(Faculty faculty)
    {
        dbContext.Faculties.Add(faculty);
    }

    public void Delete(IReadOnlyCollection<Faculty> faculties)
    {
        dbContext.Faculties.RemoveRange(faculties);
    }
}
