namespace University.Api.Domain.Faculties.Requests;

public record CreateFacultyDepartmentsRequest(Guid FacultyId, Guid DepartmentId);
