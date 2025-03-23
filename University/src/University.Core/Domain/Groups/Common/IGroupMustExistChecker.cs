namespace University.Core.Domain.Groups.Common;

public interface IGroupMustExistChecker
{
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
}
