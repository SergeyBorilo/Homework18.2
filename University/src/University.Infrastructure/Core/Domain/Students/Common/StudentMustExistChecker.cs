using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Students.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Students.Common;

public class StudentMustExistChecker(UniversityDbContext universityDbContext) : IStudentMustExistChecker
{
    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await universityDbContext.Students.AsNoTracking().AllAsync(s => s.Id != id, cancellationToken);
    }
}
