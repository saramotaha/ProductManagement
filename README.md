t API

A **Product Management API** built with **.NET 8**, implementing **Clean Architecture** and **CQRS with MediatR**.  
The project demonstrates a scalable, maintainable design with clear separation of concerns across layers.

---

## 📚 Table of Contents
- [Overview](#-overview)
- [Architecture](#-architecture)
- [Features](#-features)
- [Installation](#-installation)
- [Usage](#-usage)
- [API Endpoints](#-api-endpoints)
- [Tech Stack](#-tech-stack)
- [Contributing](#-contributing)
- [License](#-license)

---

## 📌 Overview
This API provides CRUD operations for managing **Products** and **Categories**.  
It is designed following **Domain-Driven Design (DDD)** principles and uses **Domain Events** instead of direct foreign keys.

---

## 🏗 Architecture
ProductManagement/
│── ProductManagement.Api/ → API Layer (Controllers, Swagger, DI setup)
│── ProductManagement.Application/ → Application Layer (CQRS: Commands, Queries, Handlers)
│── ProductManagement.Domain/ → Domain Layer (Entities, Value Objects, Domain Events)
│── ProductManagement.Infrastructure/ → Infrastructure Layer (EF Core, Database)

markdown
Copy code

- **API Layer** → Exposes endpoints via Controllers.
- **Application Layer** → Handles business logic with CQRS + MediatR.
- **Domain Layer** → Contains entities, value objects, and domain rules.
- **Infrastructure Layer** → Database persistence with EF Core.

---

## ✨ Features
- ✅ Full CRUD for Products & Categories  
- ✅ CQRS implementation with MediatR  
- ✅ Domain Events for communication  
- ✅ EF Core for persistence  
- ✅ Swagger/OpenAPI for documentation  
- ✅ Clean Architecture design  

---

## ⚙️ Installation

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ProductManagement.git
Navigate to API project:

bash
Copy code
cd ProductManagement/ProductManagement.Api
Update database:

bash
Copy code
dotnet ef database update
Run the application:

bash
Copy code
dotnet run
🚀 Usage
Once running, API is available at:
👉 https://localhost:5001/swagger

You can test all endpoints directly using Swagger UI.

📖 API Endpoints
Products
GET /api/products → Get all products

GET /api/products/{id} → Get product by ID

POST /api/products → Create new product

PUT /api/products/{id} → Update product

DELETE /api/products/{id} → Delete product

Categories
GET /api/categories → Get all categories

POST /api/categories → Create new category

PUT /api/categories/{id} → Update category

DELETE /api/categories/{id} → Delete category

🛠 Tech Stack
.NET 8

Entity Framework Core

MediatR (CQRS)

SQL Server

Swagger / OpenAPI

🤝 Contributing
Contributions are welcome!

Fork the project

Create your feature branch (git checkout -b feature/YourFeature)

Commit changes (git commit -m 'Add new feature')

Push to branch (git push origin feature/YourFeature)

Open a Pull Request

📄 License
This project is licensed under the MIT License.
You are free to use, modify, and distribute it with attribution.

