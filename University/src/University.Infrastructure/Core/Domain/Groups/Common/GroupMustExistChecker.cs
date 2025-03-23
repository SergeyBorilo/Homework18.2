using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Groups.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Groups.Common;

public class GroupMustExistChecker(UniversityDbContext universityDbContext) : IGroupMustExistChecker
{
    public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await universityDbContext.Groups.AsNoTracking().AllAsync(g => g.Name != name, cancellationToken);
    }
}
