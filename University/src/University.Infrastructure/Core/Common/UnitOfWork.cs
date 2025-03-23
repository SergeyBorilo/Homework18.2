using University.Core.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Common;

internal class UnitOfWork(UniversityDbContext dbContext
    ) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }

}
