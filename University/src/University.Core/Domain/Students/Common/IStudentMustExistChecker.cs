namespace University.Core.Domain.Students.Common;

public interface IStudentMustExistChecker
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
