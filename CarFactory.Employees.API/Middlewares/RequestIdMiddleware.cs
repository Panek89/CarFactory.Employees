namespace CarFactory.Employees.API.Middlewares;

public class RequestIdMiddleware
{
    private readonly RequestDelegate _next;

    public RequestIdMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }
}
