# 📂 NeoArchiveAI

> **Enterprise-ready ASP.NET Core 10 backend template focused on AI-powered document management.**

NeoArchiveAI is a modern backend application built with **ASP.NET Core 10**, **Clean Architecture**, and **PostgreSQL**. The project follows **SOLID principles**, **Use Case-driven development**, and a modular architecture designed to be scalable, maintainable, and reusable for future enterprise applications.

---

# 🚀 Current Status

## ✅ Completed

- Documents CRUD
- Categories CRUD
- Users CRUD
- Clean Architecture
- Repository Pattern
- Unit of Work
- FluentValidation
- Global Exception Middleware
- Soft Delete
- Docker
- PostgreSQL
- Swagger / OpenAPI
- BCrypt Password Hashing
- Local Storage
- SHA256 Hash Service

## 🚧 In Progress

- Authentication (JWT)

## 📅 Planned

- File Storage
- OCR Integration
- Artificial Intelligence

---

# 🏗 Architecture

The project follows **Clean Architecture** to keep business rules independent from frameworks and external services.

```text
                ASP.NET Core API
                       │
                       ▼
               Application Layer
        (Use Cases / Validation)
                       │
                       ▼
                 Domain Layer
       (Business Rules / Entities)
                       │
                       ▼
            Infrastructure Layer
   (EF Core / PostgreSQL / Storage)
                       │
                       ▼
                  PostgreSQL
```

---

# 📁 Project Structure

```text
NeoArchiveAI

src/
└── backend/
    ├── NeoArchiveAI.Api
    ├── NeoArchiveAI.Application
    ├── NeoArchiveAI.Domain
    └── NeoArchiveAI.Infrastructure

docs/
├── ARCHITECTURE.md
├── CONTRIBUTING.md
├── DATABASE.md
├── DOCKER.md
└── ROADMAP.md
```

---

# ⚙️ Tech Stack

- ASP.NET Core 10
- C#
- Entity Framework Core
- PostgreSQL
- Docker
- Swagger / OpenAPI
- Clean Architecture
- Repository Pattern
- Unit of Work
- FluentValidation
- BCrypt.Net
- Soft Delete
- Local Storage
- SHA256 Hash Service

---

# ✨ Architecture Highlights

- ✅ Clean Architecture
- ✅ SOLID Principles
- ✅ Repository Pattern
- ✅ Unit of Work
- ✅ Dependency Injection
- ✅ Global Exception Middleware
- ✅ FluentValidation
- ✅ Soft Delete
- ✅ Docker Ready
- ✅ PostgreSQL
- ✅ Swagger / OpenAPI

---

# 📚 Documentation

Project documentation is organized into dedicated files.

| Document | Description |
|----------|-------------|
| ARCHITECTURE.md | System architecture |
| DATABASE.md | Database structure and queries |
| ROADMAP.md | Development roadmap |
| DOCKER.md | Docker configuration |
| CONTRIBUTING.md | Development guidelines |

---

# 📊 Project Progress

| Module | Status |
|----------|:------:|
| Infrastructure | ✅ Complete |
| Documents | ✅ Complete |
| Categories | ✅ Complete |
| Users | ✅ Complete |
| Authentication | 🚧 In Progress |
| File Storage | ⏳ Planned |
| OCR | ⏳ Planned |
| Artificial Intelligence | ⏳ Planned |

---

# 📌 Development Roadmap

## Foundation

- ✅ Clean Architecture
- ✅ Dependency Injection
- ✅ Repository Pattern
- ✅ Unit of Work
- ✅ PostgreSQL
- ✅ Entity Framework Core
- ✅ Docker
- ✅ Swagger
- ✅ FluentValidation
- ✅ Exception Middleware
- ✅ Local Storage
- ✅ SHA256 Hash Service

## Modules

### Documents

- ✅ Create Document
- ✅ Get Document
- ✅ Get Documents
- ✅ Update Document
- ✅ Delete Document

### Categories

- ✅ Create Category
- ✅ Get Category
- ✅ Get Categories
- ✅ Update Category
- ✅ Delete Category

### Users

- ✅ Create User
- ✅ Get User
- ✅ Get Users
- ✅ Update User
- ✅ Delete User

### Authentication

- 🚧 Login
- ⏳ JWT
- ⏳ Authorization
- ⏳ Refresh Token

### Future Modules

- ⏳ File Storage
- ⏳ OCR Integration
- ⏳ Artificial Intelligence

---

# 🚀 Getting Started

Clone the repository.

```bash
git clone git@github.com:evidenciasponao/NeoArchiveAI.git
```

Go to the project.

```bash
cd NeoArchiveAI
```

Restore dependencies.

```bash
dotnet restore
```

Run the API.

```bash
dotnet run --project src/backend/NeoArchiveAI.Api
```

---

# 🧪 API Documentation

Swagger is enabled during development.

```
https://localhost:5001/swagger
```

or

```
http://localhost:5000/swagger
```

---

# 🔄 Development Workflow

Every feature is implemented following the same workflow.

```text
Requirement
      │
      ▼
Architecture
      │
      ▼
Implementation
      │
      ▼
Build
      │
      ▼
Swagger Testing
      │
      ▼
PostgreSQL Verification
      │
      ▼
Git Commit
```

---

# 🎯 Design Principles

The project is built around the following principles:

- Clean Architecture
- SOLID
- Separation of Concerns
- Dependency Inversion
- Use Case Driven Development
- Domain-Centric Design
- Maintainability
- Scalability
- Testability

---

# 📄 License

This project is licensed under the MIT License.
