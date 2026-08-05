# 📂 NeoArchiveAI

> **Enterprise-ready Intelligent Document Management Backend built with ASP.NET Core 10, Clean Architecture and PostgreSQL.**

NeoArchiveAI is a backend application designed for intelligent document management systems. The project follows **Clean Architecture**, **SOLID principles**, and a **Use Case-driven** approach to build scalable, maintainable and reusable enterprise applications.

---

# 🚀 Current Status

## ✅ Completed

- Clean Architecture
- ASP.NET Core 10
- PostgreSQL
- Entity Framework Core
- Repository Pattern
- Unit of Work
- Dependency Injection
- FluentValidation
- Global Exception Middleware
- Local Storage
- SHA256 Hash Service

### Documents

- Upload Document
- Download Document
- Documents CRUD

### Categories

- CRUD

### Users

- CRUD

### Authentication

- JWT Authentication
- Authorization

### OCR

- Tesseract Integration
- Text Extraction
- ExtractedText Persistence

---

## 🚧 Next Modules

- OpenAI Integration
- Intelligent Search
- Angular Frontend

---

# 🏗 Architecture

The project follows **Clean Architecture**.

```text
                Clients
          (Postman / Angular)
                    │
                    ▼
              ASP.NET Core API
                    │
                    ▼
        Application Layer (Use Cases)
                    │
                    ▼
       Domain Layer (Business Rules)
                    │
                    ▼
 Infrastructure (EF Core / Storage)
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
- JWT Authentication
- Tesseract OCR
- FluentValidation
- BCrypt.Net
- Local Storage
- SHA256
- Clean Architecture

---

# ✨ Implemented Features

- ✅ Clean Architecture
- ✅ Repository Pattern
- ✅ Unit of Work
- ✅ Dependency Injection
- ✅ JWT Authentication
- ✅ Users CRUD
- ✅ Categories CRUD
- ✅ Documents CRUD
- ✅ Document Upload
- ✅ Document Download
- ✅ Local Storage
- ✅ SHA256 Hash
- ✅ OCR Extraction
- ✅ PostgreSQL
- ✅ Docker

---

# 📊 Project Progress

| Module | Status |
|----------|:------:|
| Architecture | ✅ |
| Documents | ✅ |
| Categories | ✅ |
| Users | ✅ |
| Authentication | ✅ |
| Local Storage | ✅ |
| OCR | ✅ |
| OpenAI | 🚧 |
| Intelligent Search | 🚧 |
| Angular Frontend | 🚧 |

---

# 📚 Documentation

| Document | Description |
|----------|-------------|
| ARCHITECTURE.md | System architecture |
| DATABASE.md | Database documentation |
| ROADMAP.md | Development roadmap |
| DOCKER.md | Docker configuration |
| CONTRIBUTING.md | Development guidelines |

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

# 🔄 Development Workflow

Every feature follows the same workflow.

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
Postman Validation
      │
      ▼
PostgreSQL Verification
      │
      ▼
Git Commit
```

---

# 🎯 Design Principles

The project is built around:

- Clean Architecture
- SOLID Principles
- Separation of Concerns
- Dependency Injection
- Repository Pattern
- Unit of Work
- Use Case Driven Development
- Maintainability
- Scalability
- Reusability

---

# 📌 Roadmap

Current milestone:

- ✅ Document Management
- ✅ Authentication
- ✅ OCR

Next milestone:

- 🚧 OpenAI Integration
- 🚧 Intelligent Search
- 🚧 Angular Frontend

For more details, see **docs/ROADMAP.md**.

---

# 📄 License

This project is licensed under the MIT License.
