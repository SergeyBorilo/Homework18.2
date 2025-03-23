namespace University.Application.Domain.Groups.Queries.GetGroups;

public record StudentsDto
{
    public Guid StudentId { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? MiddleName { get; init; }

    public string? PasportSerialNumber { get; init; }

    public Guid GroupId { get; init; }

}
