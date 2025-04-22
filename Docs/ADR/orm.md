## ADR - ORM

[Back to table of contents](composite.md)

### Status
- Accepted

### Context
We need ORM (Object-Relational Mapping) in our project. The key requirements
- Relational
- Free to use, either commercial
- Which will have a provider from the ORM used in the project

### SWOT

| **Strengths**                                                       | **Weaknesses**                                     |
|---------------------------------------------------------------------|----------------------------------------------------|
| Simplifies database access and CRUD operations                      | Requires understanding of EF Core conventions      |
| Supports multiple database providers (SQL Server, PostgreSQL, etc.) | Potential performance overhead compared to raw SQL |
| Strong integration with .NET ecosystem                              | Limited control over complex SQL queries           |
| Active community and frequent updates                               | Debugging issues can be tricky in some scenarios   |

| **Opportunities**                                          | **Threats**                                               |
|------------------------------------------------------------|-----------------------------------------------------------|
| Growing demand for ORM tools in modern applications        | Competition from other ORMs (e.g., Dapper, NHibernate)    |
| Enhanced features for cloud and microservices applications | Risk of over-reliance leading to less optimized queries   |
| Expanding support for NoSQL databases                      | Changes in database technology could impact compatibility |
| Evolving .NET ecosystem provides additional capabilities   | Potential security risks with improper configurations     |

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