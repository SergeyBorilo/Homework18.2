using University.Core.Common;
using University.Core.Domain.Faculties.Data;
using University.Core.Domain.Faculties.Validator;

namespace University.Core.Domain.Faculties.Models;

public class Faculty : Entity
{
    private Faculty() { }

    public Faculty(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    public IReadOnlyCollection<FacultyDepartment> Departments { get; init; }

    public static Faculty Create(CreateFacultyData data)
    {
        Validate(new CreateFacultyValidator(), data);

        return new Faculty{ Id = Guid.NewGuid(), Name = data.Name };
    }
}
