using MediatR;

namespace University.Application.Domain.Faculties.Queries.GetFacultyDetails;

public record GetFacultyDetailsQuery(Guid Id) : IRequest<FacultyDetailsDto>;
