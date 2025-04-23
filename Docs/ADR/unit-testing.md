## ADR - Unit Testing

[Back to table of contents](composite.md)

### Status
- Proposed

### Context
As a Team, we need rules on how to write readable and understandable unit tests in application.

### Decision
In this ADR we decide to start with prepare rules for Unit Testing.
- Do not use abbreviated forms in English
- One test file for one service/repository
- Use region - per method
- NUnit library version ^4.*
- Happy and negative paths

### Consequences

Positive:
- Tests will be readable for everyone.
- For new team members it will be easier to understand and start write tests.

Negative:
- Lots of Developers not too keen on tests.