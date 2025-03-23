namespace University.Application.Domain.Groups.Queries.GetGroups;

public record GroupDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public IReadOnlyCollection<StudentsDto> StudentsCollection { get; init; }
}
