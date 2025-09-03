# 🛒 Product Management API

A **Product Management API** built with **.NET 8**, implementing **Clean Architecture** and **CQRS with MediatR**.  
The project demonstrates a scalable, maintainable design with clear separation of concerns across layers.  
👉 Using **EF Core In-Memory Database** (no SQL setup required).

---

## 📚 Table of Contents
- [Overview](#-overview)
- [Architecture](#-architecture)
- [Features](#-features)
- [Installation](#-installation)
- [Usage](#-usage)
- [API Endpoints](#-api-endpoints)
- [Tech Stack](#-tech-stack)
- [Notes](#-notes)

---

## 📌 Overview
This API provides CRUD operations for **Products** and limited operations for **Categories**.  
It is designed following **Clean Architecture** principles with **CQRS + MediatR** and respects **DDD aggregate boundaries** (Products and Categories communicate without direct foreign keys).

---

## 🏗 Architecture
ProductManagement/
│── ProductManagement.Api/ → API Layer (Controllers, Swagger, DI setup)
│── ProductManagement.Application/ → Application Layer (CQRS: Commands, Queries, Handlers)
│── ProductManagement.Domain/ → Domain Layer (Entities, Value Objects, Domain Events)
│── ProductManagement.Infrastructure/→ Infrastructure Layer (EF Core In-Memory)

markdown
Copy code

- **API Layer** → Exposes endpoints via Controllers.  
- **Application Layer** → Handles business logic with CQRS + MediatR.  
- **Domain Layer** → Contains entities and domain rules.  
- **Infrastructure Layer** → Persistence with EF Core (In-Memory).  

---

## ✨ Features
- ✅ Full CRUD for **Products**  
- ✅ `GetAll` + `Delete` for **Categories**  
- ✅ CQRS implementation with MediatR  
- ✅ Domain-Driven Design aggregate boundaries respected  
- ✅ EF Core with In-Memory Database (no setup required)  
- ✅ Swagger/OpenAPI for documentation  

---

## ⚙️ Installation

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/saramotaha/ProductManagement.git
Navigate to API project:

bash
Copy code
cd ProductManagement/ProductManagement.Api
Run the application:

bash
Copy code
dotnet run
🚀 Usage
Once running, API is available at:
👉 https://localhost:7274/swagger

You can test all endpoints directly using Swagger UI.

📖 API Endpoints
🔹 Products
Method	Endpoint	Description
GET	/api/Product	Get all products
GET	/api/Product/{id}	Get product by ID
POST	/api/Product	Create a new product
PUT	/api/Product	Update an existing product
DELETE	/api/Product/{id}	Delete a product by ID

🔹 Categories
Method	Endpoint	Description
GET	/api/Category	Get all categories
DELETE	/api/Category/{id}	Delete a category by ID

🛠 Tech Stack
.NET 8

Entity Framework Core (In-Memory)

MediatR (CQRS)

Swagger / OpenAPI

📝 Notes
Database → Uses EF Core In-Memory (data is reset on each app restart).

Categories → Only supports GetAll and Delete.

Products → Full CRUD operations available.

DDD → No direct foreign keys between Product and Category aggregates (uses validation + domain events).

