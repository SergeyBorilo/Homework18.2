using University.Core.Common;
using University.Core.Domain.Groups.Data;
using University.Core.Domain.Groups.Validator;
using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Groups.Models;

public class Group : Entity
{
    private Group() { }

    public Group(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    public IReadOnlyCollection<Student> Students { get; init; }

    public static Group Create(CreateGroupData data)
    {
        Validate(new CreateGroupValidator(), data);

        return new Group { Id = Guid.NewGuid(), Name = data.Name};
    }
}
