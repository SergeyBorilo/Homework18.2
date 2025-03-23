namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record DepartmentsDto
{
    public Guid DepartmentId { get; init; }

    public string? DepartmentName { get; init; }
}
