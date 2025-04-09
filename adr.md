# ADR Document

This document describes Achitecture Decision Record for Employees microservice.

## Table of contents

1. [Main Technology](#main-technology)
2. [ORM](#orm)
3. [Database](#database)
4. [Repositories](#repositories)
5. [Unit Testing](#unit-testing)

## Main Technology

[Back to table of contents](#table-of-contents)

### Status
- Accepted

### Context
We need framework for building a scalable and maintainable web API for our project. The key requirements include:
- Cross-platform compatibility.
- Long-term support.
- Good and clear documentation.
- Integration with modern development tools and cloud services.

### Decision
We have decided to use ASP.NET Core WEB API as the main framework to develop that microservice.
- ASP.NET Core is open-source and cross-platform, allowing flexibility in deployment.
- It integrates easily with Azure and other cloud services or public clouds.
- It's open-source, so it can be hosted in most hostings.
- The framework is maintained by Microsoft and have a large, active community, so it should have long support.
- Complete tools provided free of charge, even for commercial use (e.g. Visual Studio Code).

### Consequences

Positive:
- Team is experienced in this technology.
- Access to a wide range libraries and tools within the .NET ecosystem.
- Very good and clear documentation.
- Lot's of free tutorials all over the internet.

Negative:
- No opportunity to discover new technologies.

## ORM

[Back to table of contents](#table-of-contents)

### Status
- Accepted

### Context
We need ORM (Object-Relational Mapping) in our project. The key requirements
- Relational
- Free to use, either commercial
- Which will have a provider from the ORM used in the project

### Decision
We decide to use EntityFramework Core. Decision rationale:
- EF Core is designed specifically for .NET Core, ensuring seamless compatibility and leveraging the latest framework features.
- EF Core supports both code-first and database-first approaches, accommodating potential changes in our database design process.
- The LINQ-based query syntax and built-in tools (e.g., migrations, scaffolding) reduce boilerplate code and accelerate development.
- As a Microsoft-supported project, EF Core benefits from regular updates, extensive documentation, and a large community.

### Consequences
Positive:
- Faster onboarding for developers familiar with .NET and EF Core.
- Simplified database migrations and schema management.
- Reduced need for custom SQL in most cases due to LINQ support.

Negative:
- Regularly review EF Core releases to stay aligned with best practices.

## Database

[Back to table of contents](#table-of-contents)

### Status
- Accepted

### Context
We need Database engine for store Data in our project. The key requirements
- Relational
- Free to use, either commercial
- Which will have a provider from the ORM used in the project

### Decision
We have decided to use MSSQL as the Database engine.
- Free to use, with certain limitations even commercially
- Selected ORM has a provider
- Very good free tools (e.g SQL Server Management Studio)

### Consequences

Positive:
- Team is experienced in this Database engine.
- MSSQL is from the same software provider as ORM and Framework.
- Very well documentation and strong support from Microsoft.

Negative:
- In some scenarios non-relational DB is much faster.
- PostgreSQL is free to use without any restrictions.

## Repositories

[Back to table of contents](#table-of-contents)

### Status
- Proposed

### Context
We need a design breakdown of the instrastructure application layer that:
- Will be separated from other layers
- It will be easy swap to another ORM if needed
- Easily expandable
- Easily testable

### Decision
Use Repository Pattern with UoW
- Base Repository Class and Interface with Generic Entity Type
- Unit of Work pattern implemented

### Consequences

Positive:
- Sharing for repetitive operations between different entities
- Better segregation for individual entities

Negative:
- A great deal of opinion is against the use of the repository pattern along with EF Core.

## Unit Testing

[Back to table of contents](#table-of-contents)

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