using CarFactory.Employees.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFactory.Employees.Domain.Models;

public class Employee : BaseEntity
{
    private DateTime _employmentStartDate;
    private DateTime? _employmentEndDate;
    private DateTime? _dateOfBirth;

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required PersonalId PersonalId { get; set; }
    public bool IsEmployed { get; set; }

    public DateTime EmploymentStartDate 
    { 
        get { return _employmentStartDate; }  
        set
        {
            if (_employmentStartDate == DateTime.MinValue)
            {
                throw new ArgumentException("Employment start date can't be Minimum Value", nameof(_employmentStartDate));
            }

            if (_employmentStartDate == DateTime.MaxValue)
            {
                throw new ArgumentException("Employment start date can't be Maximum Value", nameof(_employmentStartDate));
            }

            if (_employmentEndDate.HasValue && _employmentStartDate < _employmentEndDate)
            {
                throw new ArgumentException("Employment start date can't be earlier than _employmentEndData", nameof(_employmentStartDate));
            }
            _employmentStartDate = value;
        }
    }

    public DateTime? EmploymentEndDate
    {
        get { return _employmentEndDate; }
        set
        {
            if (_employmentStartDate == DateTime.MinValue)
            {
                throw new ArgumentException("Employment end date can't be Minimum Value", nameof(_employmentEndDate));
            }

            if (_employmentStartDate == DateTime.MaxValue)
            {
                throw new ArgumentException("Employment end date can't be Maximum Value", nameof(_employmentEndDate));
            }

            _employmentEndDate = value;
        }
    }

    public DateTime DateOfBirth {get; internal set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public string FullNameReverse => $"{LastName} {FirstName}";
}
