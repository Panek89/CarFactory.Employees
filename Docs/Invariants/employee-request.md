# EmployeeRequest Invariants

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [EmployeeRequest](/CarFactory.Employees.Domain/Models/EmployeeRequest.cs) Model which represents request for new Employee/Employees.

## NoOfEmployeesNeeded Invariants

- Cannot be null
- Cannot have value 0 or below
- Maximum value is 10

## Business Invariants

- Cannot be null or empty
- Must have at least 2 characters
- Only letters and digits allowed

## StartDate Invariants

- Cannot have default value
- Cannot be in the past
- Must be at least one month before current date
- Cannot be later than half year from current date

## Candidates Invariants 

- At Registered, RejectedByHr, NoCandidates status cannot be candidates
- Number of Candidates cannot be greater than NoOfEmployeesNeeded
