using MediatR;

namespace University.Application.Domain.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(IReadOnlyCollection<Guid> Ids) : IRequest;
