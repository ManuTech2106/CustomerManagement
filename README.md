COMPLETED WORK:

Build a C# AspNetCore REST API, with an in-memory SQLite DB. Use .net 7.0. with 3 endpoints / routes - This has been completed and I have created more then 3 endpoints just to see the complete data.
Customer Model - This is also completed.


Implementation Requirements (things we want to see)

· Separate Functions (i.e. front door / entry point), business logic and data manager projects / layers - It has been completed

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
