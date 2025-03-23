namespace University.Application.Domain.Students.Queries.GetStudentDetails;

public record StudentDetailsDto
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? MiddleName { get; init; }

    public Guid GroupId { get; init; }

    public string? GroupName { get; init; }
}
