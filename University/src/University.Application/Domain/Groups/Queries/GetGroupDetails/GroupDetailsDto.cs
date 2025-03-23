using University.Application.Domain.Groups.Queries.GetGroups;

namespace University.Application.Domain.Groups.Queries.GetGroupDetails;

public record GroupDetailsDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public IReadOnlyCollection<StudentsDto> StudentsCollection { get; init; }
}
