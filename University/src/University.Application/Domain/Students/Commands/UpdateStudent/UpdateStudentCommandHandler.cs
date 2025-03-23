using MediatR;
using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Application.Domain.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler(IStudentsRepository studentsRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentsRepository.FindAsync(request.Id, cancellationToken);
    }
}
