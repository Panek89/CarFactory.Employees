## ADR - Database

[Back to table of contents](composite.md)

### Status
- Accepted

### Context
We need Database engine for store Data in our project. The key requirements
- Relational
- Free to use, either commercial
- Which will have a provider from the ORM used in the project

### SWOT

| **Strengths**                               | **Weaknesses**                          |
|---------------------------------------------|-----------------------------------------|
| Reliable and robust performance             | Licensing costs can be high             |
| Excellent integration with Microsoft tools  | Complex configuration for beginners     |
| Strong support for transactional operations | Limited support for non-relational data |
| Advanced security features                  | Platform dependency on Windows          |

| **Opportunities**                           | **Threats**                                          |
|---------------------------------------------|------------------------------------------------------|
| Growing demand for enterprise databases     | Competition from open-source databases               |
| Enhanced integration with cloud platforms   | Potential vulnerabilities in large-scale deployments |
| Increasing need for data analytics tools    | Technology rapidly evolving, risks of obsolescence   |
| Expanding features for big data             | Security challenges in distributed environments      |

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