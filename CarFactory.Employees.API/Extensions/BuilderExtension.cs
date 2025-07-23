using CarFactory.Employees.SharedLibrary.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CarFactory.Employees.API.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder ConfigureOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettingsConfiguration>(builder.Configuration.GetSection(AppSettingsConfiguration.AppSettings));
        builder.Services.Configure<KeycloakConfiguration>(builder.Configuration.GetSection(KeycloakConfiguration.Keycloak));

        return builder;
    }

    public static WebApplicationBuilder ConfigureJwt(this WebApplicationBuilder builder, KeycloakConfiguration keycloakConfiguration)
    {
        string keycloakAuthority = $"http://{keycloakConfiguration.Host}:{keycloakConfiguration.Port}/realms/{keycloakConfiguration.Realm}";

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = keycloakAuthority;
                options.Audience = keycloakConfiguration.Audience;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = keycloakAuthority,
                    ValidateAudience = true,
                    ValidAudience = keycloakConfiguration.Audience,
                    ValidateLifetime = true
                };
            });

        return builder;
    }
}
