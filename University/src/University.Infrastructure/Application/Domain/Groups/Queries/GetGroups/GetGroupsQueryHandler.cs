using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Common;
using University.Application.Domain.Groups.Queries.GetGroups;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Application.Domain.Groups.Queries.GetGroups;

public class GetGroupsQueryHandler(UniversityDbContext universityDbContext) : IRequestHandler<GetGroupQuery, PageResponse<GroupDto[]>>
{
    public async Task<PageResponse<GroupDto[]>> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = universityDbContext.Groups.AsNoTracking()
            .Include(x => x.Students);

        var skip = (request.PageNumber - 1) * request.PageSize;
        var data = await sqlQuery
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(request.PageSize)
            .Select(x => new GroupDto()
            {
                Id = x.Id,
                Name = x.Name,
                StudentsCollection = x.Students.Select(student => new StudentsDto()
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    MiddleName = student.MiddleName
                }).ToArray()
            })
            .ToArrayAsync(cancellationToken);
        return new PageResponse<GroupDto[]>();
    }
}
