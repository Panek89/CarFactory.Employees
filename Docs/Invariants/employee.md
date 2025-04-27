# Employee Invariants

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [Employee](/CarFactory.Employees.Domain/Models/Employee.cs) Model which represents new Employee.

## EmploymentStartDate Invariants

- Start date of employment of the employee does not have to coincide exactly with the date of the demand, we can accept the employee a little earlier or a few days after the date, maximum +- one week

## EmploymentEndDate Invariants

- Employee must work at least one day, if he does not show up for work, he is not hired at all
- An employee may be dismissed in advance or on a given day if he or she has broken the rules

## DateOfBirth Invariants

- The legal requirement allows only adult employees to be employed (minimum 18 years old)
- Due to the difficult conditions at our plants, employees of retirement age, i.e. over 60 years of age for women and 65 years of age for men, cannot work for us

## FirstName, LastName Invariants

- Name and surname cannot contain any characters other than letters
- It can't be short, the law prohibits one-letter names or surnames

## PersonalId Invariants

- Domain requirements are equivalent to [PersonalId](personal-id.md)

## IsEmployed

- System must contain clear information whether the employee is currently employed or not, also with the possibility of checking the date in the past or in the future
