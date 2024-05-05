Description:

1. CustomerManagement.API - This project holds all API Endpoints like GetCustomers, GetCustomerById, GetCustomerByAge, Create a new customer and Patch Customer along with Swagger to execute any endpoint.
2. CustomerManagement.Service - This project is a service layer. This contains all business logic to perform on Get, Post and other operations, like GetCustomerByAge.
3. CustomerManagement.Infra - This project has everything related to DBContext, a Repository to interact with the Database.
4. CustomerManagement.Core - This project contains all entities or models, currently we have only one Customer entity.
5. CustomerManagement.UI - This is an Angular Project. It has a user interface to view data in tabular format and other operations as well.

Layer Interaction:

Web API Endpoints or Entry Point (Swagger) --> CustomerManagement.API --> CustomerManagement.Service --> CustomerManagement.Infra --> Database (or CustomerManagement.Core)

CustomerManagement.UI --> Web API Entry Point


Note: Angular UI Implementation is not in requirement, just created this UI for a better view of data and to refresh my knowledge as well.

COMPLETED WORK:

Build a C# AspNetCore REST API, with an in-memory SQLite DB. Use .net 7.0. with 3 endpoints/routes - This has been completed and I have created more than 3 endpoints, just to see the complete data.
Customer Model - This is also completed.


Implementation Requirements (things we want to see)

· Separate Functions (i.e. front door/entry point), business logic and data manager projects/layers - It has been completed

· Validation and error messages returned to callers - It is also completed.

· Dependency Injection - This is also implemented.

· Use of code first Entity Framework - This is also implemented.

· Unit tests using xUnit, Moq and FluentAssertions - This is also implemented (Partially around 75 to 80% test cases have been completed)



PENDING (In Progress):
I am also trying to create an Angular App to consume APIs in Angular UI - Anyway this is not in requirement but still creating to get a good UI.

Additional Functional Requirements
· Whenever a new customer record is created (i.e. POST endpoint), call an API to generate a profile image for the customer

· Use the following API call: https://ui-avatars.com/api/?name=<FULL_NAME>&format=svg

· e.g. https://ui-avatars.com/api/?name=John+Doe&format=svg

· Store the returned SVG data in a new field in the customer record.
