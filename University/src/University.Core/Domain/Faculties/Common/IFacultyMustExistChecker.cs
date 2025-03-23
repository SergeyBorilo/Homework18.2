namespace University.Core.Domain.Faculties.Common;

public interface IFacultyMustExistChecker
{
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
}
