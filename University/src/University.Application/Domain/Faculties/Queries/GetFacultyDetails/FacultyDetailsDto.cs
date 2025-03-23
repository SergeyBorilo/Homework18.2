using University.Application.Domain.Faculties.Queries.GetFaculties;

namespace University.Application.Domain.Faculties.Queries.GetFacultyDetails;

public record FacultyDetailsDto
{
    public FacultyDetailsDto(IReadOnlyCollection<DepartmentsDto> departmentsCollection)
    {
        DepartmentsCollection = departmentsCollection;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    public IReadOnlyCollection<DepartmentsDto> DepartmentsCollection { get; init; }
}
