namespace University.Core.Domain.Departments.Common;

public interface IDepartmentMustExistChecker
{
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
}
