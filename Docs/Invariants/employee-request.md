# EmployeeRequest Invariants

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [EmployeeRequest](/CarFactory.Employees.Domain/Models/EmployeeRequest.cs) Model which represents request for new Employee/Employees.

## NumberOfEmployeesNeeded Invariants

- The number of employee requirements must be a minimum requirement for one employee and a maximum of ten

## Business Invariants

- The request must include the name of the business that is submitting the request.

## StartDate Invariants

- The demand for employees can only be made in the future, at least one month in advance

## Candidates Invariants 

- Number of candidates cannot exceed the number of employees required, in which case a new request must be submitted
