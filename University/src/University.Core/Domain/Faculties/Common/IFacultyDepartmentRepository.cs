using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;

public interface IFacultyDepartmentRepository
{
    public void Add(FacultyDepartment facultyDepartment);

    public Task<FacultyDepartment> FindFacultyDepartmentAsync(Guid facultyId, CancellationToken cancellationToken);

    public void Delete(FacultyDepartment facultyDepartment);
}
