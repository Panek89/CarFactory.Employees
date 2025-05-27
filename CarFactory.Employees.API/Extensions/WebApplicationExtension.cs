using CarFactory.Employees.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.API.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication RegisterDevelopment(this WebApplication application)
    {
        application.MapOpenApi();
        application.UseSwagger();
        application.UseSwaggerUI();

        return application;
    }

    public static WebApplication RegisterNonDevelopment(this WebApplication application)
    {
        application.UseHttpsRedirection();

        return application;
    }

    public static WebApplication RunMigrations(this WebApplication application)
    {
        using (var scope = application.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }

        return application;
    }
}
