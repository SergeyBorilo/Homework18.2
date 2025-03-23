namespace University.Api.Domain.Students.Requests;

public record DeleteStudentRequest
{
    public Guid Id { get; init; }
}
