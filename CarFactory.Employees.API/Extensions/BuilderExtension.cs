using CarFactory.Employees.SharedLibrary.Options;

namespace CarFactory.Employees.API.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder ConfigureOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettingsConfiguration>(builder.Configuration.GetSection(AppSettingsConfiguration.AppSettings));
        builder.Services.Configure<KeycloakConfiguration>(builder.Configuration.GetSection(KeycloakConfiguration.Keycloak));

        return builder;
    }
}
