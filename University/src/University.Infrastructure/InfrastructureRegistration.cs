using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Students.Common;
using University.Infrastructure.Core.Common;
using University.Infrastructure.Core.Domain.Departments.Common;
using University.Infrastructure.Core.Domain.Faculties.Common;
using University.Infrastructure.Core.Domain.Groups.Common;
using University.Infrastructure.Core.Domain.Students.Common;

namespace University.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructure(this IServiceCollection service)
    {
        service.AddMediatR(o => o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        service.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repository
        service.AddScoped<IStudentsRepository, StudentsRepository>();
        service.AddScoped<IDepartmentRepository, DepartmentsRepository>();
        service.AddScoped<IFacultyRepository, FacultiesRepository>();
        service.AddScoped<IFacultyDepartmentRepository, FacultyDepartmentRepository>();
        service.AddScoped<IGroupRepository, GroupsRepository>();

        //Checkers
        service.AddScoped<IDepartmentMustExistChecker, DepartmentMustExistChecker>();
        service.AddScoped<IFacultyMustExistChecker, FacultyMustExistChecker>();
        service.AddScoped<IGroupMustExistChecker, GroupMustExistChecker>();
        service.AddScoped<IStudentMustExistChecker, StudentMustExistChecker>();
    }
}
