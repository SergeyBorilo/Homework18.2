namespace University.Core.Domain.Departments.Data;

public record CreateDepartmentData
{
    public string Name { get; init; }
    public Guid FacultyId { get; init; }

    public CreateDepartmentData(string name, Guid facultyId)
    {
        Name = name;
        FacultyId = facultyId;
    }

    public CreateDepartmentData()
    {
    }
}
