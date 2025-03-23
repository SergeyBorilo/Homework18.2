namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record FacultyDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public IReadOnlyCollection<DepartmentsDto> DepartmentsCollection { get; init; }
}
