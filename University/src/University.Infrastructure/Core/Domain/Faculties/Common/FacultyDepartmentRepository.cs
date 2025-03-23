using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties.Common;

public class FacultyDepartmentRepository(UniversityDbContext dbContext) : IFacultyDepartmentRepository
{
    public void Add(FacultyDepartment facultyDepartment)
    {
        dbContext.FacultyDepartments.Add(facultyDepartment);
    }

    public async Task<FacultyDepartment> FindFacultyDepartmentAsync(Guid facultyId, CancellationToken cancellationToken)
    {
        return await dbContext.FacultyDepartments.SingleOrDefaultAsync(fd => fd.FacultyId == facultyId, cancellationToken);
    }

    public void Delete(FacultyDepartment facultyDepartment)
    {
        dbContext.FacultyDepartments.RemoveRange(facultyDepartment);
    }
}
