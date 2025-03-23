using MediatR;

namespace University.Application.Domain.Faculties.Commands.DeleteFacultyDepartments;

public record DeleteFacultyDepartmentsCommand(IReadOnlyCollection<Guid> FacultyId) : IRequest;
