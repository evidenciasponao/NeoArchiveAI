# 📂 NeoArchiveAI

> AI-powered Digital Document Management System built with **ASP.NET Core 10**, **Clean Architecture** and **PostgreSQL**.

NeoArchiveAI is a modern backend application for digital document management. The project is being developed incrementally following **Clean Architecture**, **SOLID principles**, and a **Use Case driven** approach.

---

# 🚀 Features

- ✅ Create Document
- ✅ Get Document by Id
- ✅ Get Documents
- ✅ Update Document
- ⏳ Delete Document
- ⏳ Categories
- ⏳ Users
- ⏳ Authentication (JWT)
- ⏳ OCR Integration
- ⏳ Artificial Intelligence

---

# 🏗 Architecture

The project follows **Clean Architecture**.

```
Presentation (API)
        │
        ▼
Application
        │
        ▼
Domain
        │
        ▼
Infrastructure
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
```

---

# ⚙️ Tech Stack

- ASP.NET Core 10
- C#
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI
- Clean Architecture
- Repository Pattern
- Unit of Work - 
- FluentValidation
- Local Storage
- SHA256 Hash Service

---

# 📚 Documentation

The project documentation is organized into dedicated files.

| Document | Description |
|----------|-------------|
| ARCHITECTURE.md | System architecture |
| DATABASE.md | Database design |
| ROADMAP.md | Development roadmap |
| DOCKER.md | Docker deployment |
| CONTRIBUTING.md | Contribution guide |

---

# 📌 Development Roadmap

## Architecture

- ✅ Solution
- ✅ Domain
- ✅ Application
- ✅ Infrastructure
- ✅ API
- ✅ PostgreSQL
- ✅ Entity Framework Core
- ✅ Repository Pattern
- ✅ Unit of Work
- ✅ Local Storage
- ✅ Hash Service
- ✅ Swagger

## Use Cases

- ✅ CU-001 Create Document
- ✅ CU-002 Get Document
- ✅ CU-003 Get Documents
- ✅ CU-004 Update Document
- ⏳ CU-005 Delete Document
- ⏳ CU-006 Categories
- ⏳ CU-007 Users
- ⏳ CU-008 Authentication
- ⏳ CU-009 OCR
- ⏳ CU-010 Artificial Intelligence

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

Restore packages.

```bash
dotnet restore
```

Run the API.

```bash
dotnet run --project src/backend/NeoArchiveAI.Api
```

---

# 🧪 API

Swagger is enabled during development.

```
https://localhost:5001/swagger
```

or

```
http://localhost:5000/swagger
```

---

# 👨‍💻 Development Workflow

Every feature is developed following this process:

```
Analyze
    ↓
Design
    ↓
Implementation
    ↓
Compilation
    ↓
Swagger Testing
    ↓
PostgreSQL Verification
    ↓
Git Commit
```

---

# 📄 License

This project is licensed under the MIT License.