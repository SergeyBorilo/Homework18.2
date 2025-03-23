using System.Text.RegularExpressions;
using University.Core.Common;
using University.Core.Domain.Students.Data;
using University.Core.Domain.Students.Validator;

namespace University.Core.Domain.Students.Models;

public class Student : Entity
{
    private Student() { }

    private Student(Guid id, string firstName, string lastName, string middleName, string pasportSerialNumber,
        Guid groupId, Guid dataGroupId = default)
    {
        DataGroupId = dataGroupId;
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        PasportSerialNumber = pasportSerialNumber;
        GroupId = groupId;
    }

    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string MiddleName { get; init; }

    public string PasportSerialNumber { get; init; }

    public Group Group { get;}

    public Guid DataGroupId { get; }
    public Guid GroupId { get;  }

    public static Student? Create(CreateStudentData data)
    {
        Validate(new CreateStudentValidator(), data);

        return new Student(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName,
            data.MiddleName,
            data.PassportSerialNumber,
            data.GroupId
        );
    }
}
