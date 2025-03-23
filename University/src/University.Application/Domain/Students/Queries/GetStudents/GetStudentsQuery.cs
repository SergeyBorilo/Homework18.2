using MediatR;
using University.Application.Common;
using University.Application.Domain.Groups.Queries.GetGroups;

namespace University.Application.Domain.Students.Queries.GetStudents;

public record GetStudentsQuery(int PageSize, int PageNumber) : IRequest<PageResponse<GetStudentsDto[]>>, IRequest<PageResponse<StudentsDto[]>>;
