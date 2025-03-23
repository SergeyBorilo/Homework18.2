using MediatR;
using University.Application.Common;

namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record GetFacultyQuery(int PageNumber, int PageSize) : IRequest<FacultyDto[]>, IRequest<PageResponse<FacultyDto[]>>;
