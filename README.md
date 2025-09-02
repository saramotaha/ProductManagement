# ProductManagement

## Description
A Products Management API built with .NET Core using Clean Architecture, CQRS, and Domain Events.

## Setup Instructions
1. Clone the repository:
   git clone https://github.com/saramotaha/ProductManagement
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Update the connection string in appsettings.json if needed
5. Run the project (F5) or start debugging
6. Swagger is available at https://localhost:{port}/swagger

## Architecture Overview
- Domain Layer: Entities like Product, Category
- Application Layer: CQRS commands, handlers, and notifications
- Infrastructure Layer: Database access (EF Core + SQLite)
- API Layer: RESTful endpoints
- MediatR used for CQRS and Domain Events
- No direct foreign keys between Product and Category

## Implementation Notes
- Applied Clean Architecture and SOLID principles
- CategoryDeletedEvent triggers updates to related Products
- Swagger documentation added
