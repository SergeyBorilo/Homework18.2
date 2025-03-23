using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;

namespace University.Application.Domain.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
    {
        var group = await groupRepository.FindManyAsync(command.Ids, cancellationToken);

        groupRepository.Delete(group);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
