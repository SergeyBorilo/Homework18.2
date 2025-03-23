using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Students.Common;

public class StudentsRepository(UniversityDbContext dbContext) : IStudentsRepository
{
    public async Task<Student?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Students.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Student>> FindManyAsync(Guid ids, CancellationToken cancellationToken)
    {
        return await dbContext.Students.Where(s => s.Id == ids).ToArrayAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Student?>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await dbContext.Students.Where(s => ids.Contains(s.Id)).ToArrayAsync(cancellationToken);
    }

    public void AddStudent(Student? student)
    {
        dbContext.Students.Add(student);
    }

    public void DeleteStudent(IReadOnlyCollection<Student> students)
    {
        dbContext.Students.RemoveRange(students);
    }
}
