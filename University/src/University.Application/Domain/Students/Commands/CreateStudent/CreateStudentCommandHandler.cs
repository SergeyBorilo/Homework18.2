using System.Diagnostics;
using MediatR;
using University.Core.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;
using University.Core.Domain.Students.Models;

namespace University.Application.Domain.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler(
    IStudentsRepository studentsRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateStudentCommand, Guid>
{
    public async Task<Guid> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateStudentData();

        var student = Student.Create(data);

        studentsRepository.AddStudent(student);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        Debug.Assert(student != null, nameof(student) + " != null");
        return student.Id;
    }
}
