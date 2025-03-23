using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Departments.Models;

namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateDepartmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateDepartmentData { Name = command.Name, FacultyId = command.FacultyId};

        var department = Department.Create(data);

        departmentRepository.Add(department);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return department.Id;
    }
}
