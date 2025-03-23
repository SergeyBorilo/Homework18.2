using MediatR;
using University.Application.Common;

namespace University.Application.Domain.Departments.Queries.GetDepartments;

public record GetDepartmentQuery(int Page, int PageSize) : IRequest<PageResponse<DepartmentDto[]>>;
