

** dotnet ef migrations

dotnet ef migrations add InitCreate --project ./Infrastructure --startup-project ./WebApi -o Data/Migrations

dotnet ef database update --project ./Infrastructure --startup-project ./WebApi

Extensibility:
1. By maintaining a strict separation between the Entities, DAL, and BLL through physically distinct DLLs, you can easily modify or extend specific aspects of the application without impacting other layers. For example, changing the database implementation in the DAL won't affect the BLL as long as the repository interfaces remain consistent.
2. Each entity and business rule are encapsulated in its own context, meaning adding new business rules or changing existing ones can often be localized to a specific part of the system.
3. The BLL communicates with the DAL through interfaces, not direct implementations. This approach means that if you need to change the data access logic or introduce a new way to interact with data sources, you can implement new repositories that adhere to these interfaces without changing the business logic layer.
