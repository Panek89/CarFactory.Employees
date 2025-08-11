using System;

namespace CarFactory.Employees.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder RequestIdHeader(this IApplicationBuilder builder)
    {
        return builder;
    }
}
