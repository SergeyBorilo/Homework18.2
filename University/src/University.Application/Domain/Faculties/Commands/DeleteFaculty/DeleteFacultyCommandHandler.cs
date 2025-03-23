using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommandHandler(
    IFacultyRepository facultyRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteFacultyCommand>
{
    public async Task Handle(DeleteFacultyCommand command, CancellationToken cancellationToken)
    {
        var faculties = await facultyRepository.FindManyAsync(command.Id, cancellationToken);

        facultyRepository.Delete(faculties);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
