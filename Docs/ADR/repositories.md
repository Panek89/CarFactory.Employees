## ADR - Repositories

[Back to table of contents](composite.md)

### Status
- Proposed

### Context
We need a design breakdown of the instrastructure application layer that:
- Will be separated from other layers
- It will be easy swap to another ORM if needed
- Easily expandable
- Easily testable

### SWOT

| **Strengths**                                              | **Weaknesses**                               |
|------------------------------------------------------------|----------------------------------------------|
| Improves code organization and maintainability             | Adds complexity to implementation            |
| Promotes separation of concerns                            | May lead to over-engineering for simple apps |
| Facilitates testing by abstracting database access         | Performance overhead due to abstraction      |
| Centralizes transaction management                         | Additional layers can reduce transparency    |

| **Opportunities**                                          | **Threats**                                                     |
|------------------------------------------------------------|-----------------------------------------------------------------|
| Increased scalability for large applications               | Modern ORMs (e.g., EF Core) already offer similar functionality |
| Easier adaptation to changing business requirements        | Risk of redundancy when combined with advanced ORM features     |
| Integration with multiple data stores                      | Misuse can result in poor design patterns                       |
| Encourages best practices in enterprise-level architecture | Technology trends moving away from these patterns               |

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