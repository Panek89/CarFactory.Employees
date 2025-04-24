
# PersonalId Invariants

[Back to table of contents](_table-of-contents.md)

Document contains all invariants related to [PersonalId](/CarFactory.Employees.Domain/ValueObjects/PersonalId.cs) Value Object which represents one string property.

## Invariants list

- Must be exactly 11 characters long
- Cannot be null
- Cannot contain spaces
- Even though it is of type string, it must contain only a sequence of digits
- Special characters, characters not allowed
