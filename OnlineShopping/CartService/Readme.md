Extensibility
1. Supporting additional data sources: you can implement multiple repositories(ICartRepository) for different data sources (e.g., an SQL database, a NoSQL database, or an in-memory data store).
2. Adding new business rules (like applying discounts): Business rules can be implemented in the CartManager without affecting the data access code.