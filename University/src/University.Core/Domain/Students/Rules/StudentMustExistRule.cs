using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Core.Domain.Students.Rules;

public class StudentMustExistRule(Guid id, IStudentMustExistChecker studentMustExistChecker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isExists = await studentMustExistChecker.ExistsAsync(id, cancellationToken);
        return Check(isExists);
    }

    private RuleResult Check(bool isExists)
    {
        if (isExists) return RuleResult.Success();
        return RuleResult.Failed($"Group name: '{id}' must be unique.");
    }
}
