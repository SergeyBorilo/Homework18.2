using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;

namespace University.Application.Domain.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepartmentCommand>
{
    public async Task Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var departments = await departmentRepository.FindManyAsync(command.Ids, cancellationToken);

        departmentRepository.Delete(departments);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
