namespace University.Application.Domain.Departments.Queries.GetDepartments;

public record DepartmentDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }
}
