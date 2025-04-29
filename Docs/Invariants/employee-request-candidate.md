# EmployeeRequestCandidate Invariants 

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [EmployeeRequestCandidate](/CarFactory.Employees.Domain/Models/EmployeeRequestCandidate.cs) Model which represents Candidate for new Employee in request.

## FirstName, LastName Invariants

- Name and surname cannot contain any characters other than letters
- It can't be short, the law prohibits one-letter names or surnames

## PersonalId Invariants

- Domain requirements are equivalent to [PersonalId](personal-id.md)

## DateOfBirth Invariants

- The legal requirement allows only adult employees to be employed (minimum 18 years old)
- Due to the difficult conditions at our plants, employees of retirement age, i.e. over 60 years of age for women and 65 years of age for men, cannot work for us

## Status Invariants

- The candidate's status must reflect their current recruitment status, e.g. whether they are just registered, rejected or have resigned

## EmployeeRequest Invariants

- It can only be if there is a demand for employees, otherwise there is no need for candidates
