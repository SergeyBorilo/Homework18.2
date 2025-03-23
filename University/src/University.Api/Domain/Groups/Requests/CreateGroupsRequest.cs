namespace University.Api.Domain.Groups.Requests;

public record CreateGroupsRequest(string Name)
{
    public Guid DepartmentId { get; set; }
}
