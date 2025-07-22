using CarFactory.Employees.SharedLibrary.Options;

namespace CarFactory.Employees.API.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder ConfigureOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettingsConfiguration>(builder.Configuration.GetSection(AppSettingsConfiguration.AppSettings));

        return builder;
    }
}
