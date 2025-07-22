using System.ComponentModel.DataAnnotations;

namespace CarFactory.Employees.SharedLibrary.Options;

public class AppSettingsConfiguration
{
    public const string AppSettings = "AppSettingsConfiguration";

    [Required]
    public RabbitMqConfiguration RabbitMq { get; set; } = new();
    [Required]
    public ContractsConfiguration Contracts { get; set; } = new();
}
