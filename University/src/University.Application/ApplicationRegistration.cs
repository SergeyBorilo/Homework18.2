﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace University.Application;

public static class ApplicationRegistration
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(o => o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
