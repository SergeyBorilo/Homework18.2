using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Common;
using University.Application.Domain.Departments.Queries.GetDepartments;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Application.Domain.Departments.Queries.GetDepartments;

public class GetDepartmentsQueryHandler(UniversityDbContext universityDbContext) : IRequestHandler<GetDepartmentQuery, PageResponse<DepartmentDto[]>>
{
    public async Task<PageResponse<DepartmentDto[]>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = universityDbContext.Departments.AsNoTracking();
        var skip = (request.Page - 1) * request.PageSize;
        var department = await sqlQuery
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(request.PageSize)
            .Select(x => new DepartmentDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToArrayAsync(cancellationToken);

        return new PageResponse<DepartmentDto[]>();
    }
}
