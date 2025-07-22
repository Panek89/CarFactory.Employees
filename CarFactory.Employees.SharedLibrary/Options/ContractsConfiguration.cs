using System.ComponentModel.DataAnnotations;

namespace CarFactory.Employees.SharedLibrary.Options;

public class ContractsConfiguration
{
    public const string Contracts = "Contracts";

    [Required(AllowEmptyStrings = false)]
    public string FactoriesQueue { get; set; } = string.Empty;
}
