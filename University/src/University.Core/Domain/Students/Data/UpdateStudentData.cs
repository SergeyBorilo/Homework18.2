namespace University.Core.Domain.Students.Data;

public record UpdateStudentData(
    Guid RequestId,
    string FirstName,
    string LastName,
    string MiddleName,
    string PasportSerialNumber);
