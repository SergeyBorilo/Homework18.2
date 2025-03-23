using MediatR;

namespace University.Application.Domain.Faculties.Commands.DeleteFaculty;

public record DeleteFacultyCommand(IReadOnlyCollection<Guid> Id) : IRequest;
