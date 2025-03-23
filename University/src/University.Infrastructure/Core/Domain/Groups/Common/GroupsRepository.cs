using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Groups.Common;

public class GroupsRepository(UniversityDbContext dbContext) : IGroupRepository
{
    public async Task<Group?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Groups.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Group>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await dbContext.Groups.Where(g => ids.Contains(g.Id)).ToArrayAsync(cancellationToken);
    }

    public void Add(Group group)
    {
        dbContext.Groups.Add(group);
    }

    public void Delete(IReadOnlyCollection<Group> groups)
    {
        dbContext.Groups.RemoveRange(groups);
    }
}
