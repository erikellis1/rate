Cinode work test
================

Instructions
------------

1. Open solution in Visual Studio (2019 used during development).
2. (If needed) Adjust the database connection string in appsettings.json.
   Default is `Server=(localdb)\\mssqllocaldb;Database=EllisRate;Trusted_Connection=True;MultipleActiveResultSets=true`.
3. Create the database by opening the Package Manager Console, and run `Update-Database`.
4. Build and start the project.

The main UI application is mounted on the root. The OpenAPI spec is mounted on https://localhost:5001/swagger/v1/swagger.json.

Components
----------
* ASPNET Core 3.1
* EFCore 3.1
* Swashbuckle 5.6 for OpenAPI specs
* AngularJS 8.2
* Bootstrap 4.3 + ng-bootstrap 5.3