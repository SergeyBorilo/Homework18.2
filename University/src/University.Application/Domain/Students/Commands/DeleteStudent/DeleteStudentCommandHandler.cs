using MediatR;
using University.Application.Domain.Students.Commands.DeleteStudent;
using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Application.Domain.Students.Commands.RemoveStudent;

public class DeleteStudentCommandHandler(IStudentsRepository studentsRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteStudentCommand>
{
    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentsRepository.FindManyAsync(request.Id, cancellationToken);
        studentsRepository.DeleteStudent(student);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
