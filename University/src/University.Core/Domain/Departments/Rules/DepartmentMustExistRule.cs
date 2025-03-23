using University.Core.Common;
using University.Core.Domain.Departments.Common;

namespace University.Core.Domain.Departments.Rules;

internal class DepartmentMustExistRule(string name, IDepartmentMustExistChecker departmentMustExistChecker) : IBuisnessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isExists = await departmentMustExistChecker.ExistsAsync(name, cancellationToken);
        return Check(isExists);
    }

    private RuleResult Check(bool isExists)
    {
        if (isExists) return RuleResult.Success();
        return RuleResult.Failed($"Department name: '{name}' must be unique.");
    }
}
