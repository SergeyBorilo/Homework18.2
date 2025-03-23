using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Common;
using University.Application.Domain.Faculties.Queries.GetFaculties;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Application.Domain.Faculties.Queries.GetFaculties;

public class GetFacultiesQueryHandler(UniversityDbContext universityDbContext) : IRequestHandler<GetFacultyQuery, PageResponse<FacultyDto[]>>
{
    public async Task<PageResponse<FacultyDto[]>> Handle(GetFacultyQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = universityDbContext.Faculties.AsNoTracking()
            .Include(x => x.Departments);

        var skip = (request.PageNumber - 1) * request.PageSize;
        var data = await sqlQuery
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(request.PageSize)
            .Select(x => new FacultyDto()
            {
                Id = x.Id,
                Name = x.Name,
                DepartmentsCollection = x.Departments.Select(department => new DepartmentsDto()
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.Department.Name
                }).ToList()
            }).ToArrayAsync(cancellationToken);
        return new PageResponse<FacultyDto[]>();
    }
}
