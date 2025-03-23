using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Faculties.Models;

public class FacultyDepartment(Guid facultyId, Guid departmentId)
{
    public Guid FacultyId { get; set; }

    public Faculty Faculty { get; set; }

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public static FacultyDepartment Create(Guid facultyId, Guid departmentId)
    {
        return new FacultyDepartment(facultyId, departmentId);
    }

}
