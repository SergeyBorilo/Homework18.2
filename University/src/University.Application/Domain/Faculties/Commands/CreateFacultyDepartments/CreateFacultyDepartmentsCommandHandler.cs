using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Data;
using University.Core.Domain.Faculties.Models;

namespace University.Application.Domain.Faculties.Commands.CreateFacultyDepartments;

public class CreateFacultyDepartmentsCommandHandler(
        IFacultyDepartmentRepository facultyDepartmentRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateFacultyDepartmentsCommand, Guid>
{
    public async Task<Guid> Handle(CreateFacultyDepartmentsCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateFacultyDepartmentsData(command.FacultyId, command.DepartmentId);

        var facultyDepartment = FacultyDepartment.Create(data.FacultyId, data.DepartmentId);

        facultyDepartmentRepository.Add(facultyDepartment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return facultyDepartment.FacultyId;
    }
}
