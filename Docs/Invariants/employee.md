# Employee Invariants

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [Employee](/CarFactory.Employees.Domain/Models/Employee.cs) Model which represents new Employee.

## EmploymentStartDate Invariants

- Cannot be null
- Cannot be a default Min or Max value
- Cannot be later than EmploymentEndDate

## EmploymentEndDate Invariants

- Can be null
- Cannot be a default Min or Max value
- Cannot be earlier than EmploymentStartDate

## DateOfBirth Invariants

- same as [EmployeeRequestCandidate](employee-request-candidate.md)

## FirstName, LastName Invariants

- same as [EmployeeRequestCandidate](employee-request-candidate.md)

## PersonalId Invariants

- same as [PersonalId](personal-id.md)

## IsEmployed

- Must be true if EmploymentEndDate is null
- Cannot be true is EmploymentEndDate has value
