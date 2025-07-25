using System;

namespace CarFactory.Employees.SharedLibrary.Options;

public class KeycloakConfiguration
{
    public const string Keycloak = "Keycloak";

    public required string Host { get; set; }
    public int Port { get; set; }
    public required string Realm { get; set; }
    public required string Audience { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string GrantType { get; set; }
}
