# ASP.NET CORE
- The database context is the main class that coordinates Entity Framework functionality for a data model
- Services such as the DB context must be registered with the dependency injection (DI) container. The container provides the service to controllers.

services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
// Adds the database context to the DI container.
// Specifies that the database context will use an in-memory database.

private readonly TodoContext _context;
// Uses DI to inject the database context (TodoContext) into the controller. The database context is used in each of the CRUD methods in the controller.

- a PUT request requires the client to send the entire updated entity, not just the changes

Attribute	Notes
[Route]	Specifies URL pattern for a controller or action.
[Bind]	Specifies prefix and properties to include for model binding.
[HttpGet]	Identifies an action that supports the HTTP GET method.
[Consumes]	Specifies data types that an action accepts.
[Produces]	Specifies data types that an action returns.