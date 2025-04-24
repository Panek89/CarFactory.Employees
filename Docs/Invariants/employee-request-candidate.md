# EmployeeRequestCandidate Invariants 

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [EmployeeRequestCandidate](/CarFactory.Employees.Domain/Models/EmployeeRequestCandidate.cs) Model which represents Candidate for new Employee in request.

## FirstName, LastName Invariants

- Names must be at least characters long
- Names should only contain letters, hyphens, apostrophes, and spaces
- Special characters and numbers are not allowed
- FirstName and LastName cannot be the same

## PersonalId Invariants

- same as [PersonalId](personal-id.md)

## DateOfBirth Invariants

- Must not be the default value
- Must be in the past
- Must represent a reasonable age (minimum 18 years old)

## Status Invariants

- Must have EmployeeCandidateStatus enum value

## EmployeeRequest Invariants

- Is required, EmployeeRequestCandidate cannot exists without EmployeeRequest
