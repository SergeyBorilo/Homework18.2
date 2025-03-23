namespace University.Api.Domain.Departments.Requests;

public record CreateDepartmentsRequest(string Name)
{
    public Guid FacultyId { get; set; }
}
