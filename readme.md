### Launch

- Update the file `appsetings.Development.json` with you mysql connection string.
- Open a terminal and use the command `dotnet ef database update` (will construct the database)
- You are ready to launch the API (`dotnet run` or the builtin functions that your ide provides)

### Migrate

remember that every changes in the `DbContext` class will changes the way your Database is shaped.
Each time you add a model using `DbSet<T>` or you changes model, do the commands: 
`dotnet ef migrations add <name of you migration>` && `dotnet ef database update`

### Rules

Keep in minds that all models must be implemented in the project `CommandLib`.
Update / creation of pure object model must be done in `CommandLib` as well.

### Tips

You can find examples of controller / service / database use them as most as possible.

use the docs:
- https://docs.microsoft.com/fr-fr/ef/core/
- https://docs.microsoft.com/fr-fr/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0