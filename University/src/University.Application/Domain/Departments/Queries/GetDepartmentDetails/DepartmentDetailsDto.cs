using University.Application.Domain.Faculties.Queries.GetFaculties;

namespace University.Application.Domain.Departments.Queries.GetDepartmentDetails;

public record DepartmentDetailsDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public List<FacultyDto> Faculties { get; init; }
}
