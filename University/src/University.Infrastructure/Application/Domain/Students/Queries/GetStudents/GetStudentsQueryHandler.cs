using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Common;
using University.Application.Domain.Groups.Queries.GetGroups;
using University.Application.Domain.Students.Queries.GetStudents;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Application.Domain.Students.Queries.GetStudents;

public class GetStudentsQueryHandler(UniversityDbContext universityDbContext) : IRequestHandler<GetStudentsQuery, PageResponse<StudentsDto[]>>
{
    public async Task<PageResponse<StudentsDto[]>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = universityDbContext.Students.AsNoTracking()
            .Include(x => x.Group);

        var skip = (request.PageNumber - 1) * request.PageSize;
        var data = await sqlQuery
            .OrderBy(student => student.Id)
            .Skip(skip)
            .Take(request.PageSize)
            .Select(student => new StudentsDto()
            {
                StudentId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                PasportSerialNumber = student.PasportSerialNumber,
                GroupId = student.GroupId
            })
            .ToArrayAsync(cancellationToken);
        return new PageResponse<StudentsDto[]>();
    }
}
