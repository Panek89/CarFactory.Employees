using System.ComponentModel.DataAnnotations;

namespace CarFactory.Employees.SharedLibrary.Options;

public class RabbitMqConfiguration
{
    public const string RabbitMq = "RabbitMq";

    [Required(AllowEmptyStrings = false)]
    public string HostName { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Username { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Password { get; set; } = string.Empty;
}
