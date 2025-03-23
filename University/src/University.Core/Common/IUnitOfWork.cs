namespace University.Core.Common;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken);

}
