namespace University.Api.Domain.Departments.Requests;

public record DeleteDepartmentRequest(IReadOnlyCollection<Guid> Id);
