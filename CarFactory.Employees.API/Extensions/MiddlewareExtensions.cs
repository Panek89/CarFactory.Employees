using CarFactory.Employees.API.Middlewares;

namespace CarFactory.Employees.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder RequestIdHeader(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<RequestIdMiddleware>();
        return builder;
    }
}
