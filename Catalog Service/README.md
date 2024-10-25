

** dotnet ef migrations

dotnet ef migrations add InitCreate --project ./Infrastructure --startup-project ./WebApi -o Data/Migrations

dotnet ef database update --project ./Infrastructure --startup-project ./WebApi