namespace University.Core.Domain.Students.Data;

public class CreateStudentData
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? PassportSerialNumber { get; set; }
    public Guid GroupId { get; set; }
}
