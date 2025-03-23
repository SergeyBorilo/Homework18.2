using University.Core.Common;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Departments.Validator;

namespace University.Core.Domain.Departments.Models;

public class Department : Entity
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public static Department Create(CreateDepartmentData data)
    {
        Validate(new CreateDepartmentValidator(), data);

        return new Department { Id = Guid.NewGuid(), Name = data.Name };
    }
}


