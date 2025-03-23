using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;

public interface IStudentsRepository
{
    public Task<Student?> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Student>> FindManyAsync(Guid ids, CancellationToken cancellationToken);

    public void AddStudent(Student? student);
    public void DeleteStudent(IReadOnlyCollection<Student> students);
}
