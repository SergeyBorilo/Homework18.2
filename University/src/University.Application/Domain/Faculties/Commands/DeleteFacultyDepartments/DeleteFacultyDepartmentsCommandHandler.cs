using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Faculties.Commands.DeleteFacultyDepartments;

public class DeleteFacultyDepartmentsCommandHandler(
    IFacultyRepository facultyRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteFacultyDepartmentsCommand>
{
    public async Task Handle(DeleteFacultyDepartmentsCommand command, CancellationToken cancellationToken)
    {
        var facultyDepartments = await facultyRepository.FindManyAsync(command.FacultyId, cancellationToken);

        facultyRepository.Delete(facultyDepartments);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
