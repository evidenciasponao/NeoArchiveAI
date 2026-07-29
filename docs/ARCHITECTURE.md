# 🏛 ARCHITECTURE

> **NeoArchiveAI Architecture Documentation**
>
> This document explains the architecture of NeoArchiveAI, the responsibilities of each project, and the design patterns used throughout the solution.

---

# 📋 Table of Contents

- Overview
- Solution Structure
- Clean Architecture
- Project Responsibilities
- Request Flow
- Dependency Injection
- Repository Pattern
- Unit of Work
- Domain Layer
- Application Layer
- Infrastructure Layer
- API Layer
- Data Flow
- Design Principles
- Benefits
- Future Improvements

---

# Overview

NeoArchiveAI is built following **Clean Architecture** principles.

The primary objective is to separate business rules from infrastructure concerns, allowing the application to remain maintainable, testable, and scalable.

The architecture promotes:

- Separation of Concerns
- Dependency Inversion
- SOLID Principles
- Testability
- Scalability
- Maintainability

---

# 🏗 Solution Structure

```text
NeoArchiveAI

src/
└── backend/
    ├── NeoArchiveAI.Api
    ├── NeoArchiveAI.Application
    ├── NeoArchiveAI.Domain
    └── NeoArchiveAI.Infrastructure
```

---

# 🧱 Clean Architecture

The solution follows the classic Clean Architecture model.

```text
                ASP.NET Core API
                       │
                       ▼
                Application
             (Use Cases)
                       │
                       ▼
                  Domain
            (Business Rules)
                       │
                       ▼
              Infrastructure
      (Database / Storage / Services)
                       │
                       ▼
                 PostgreSQL
```

Dependency direction always points inward.

```text
API
 │
 ▼
Application
 │
 ▼
Domain

Infrastructure ─────► Domain
Infrastructure ─────► Application
API ────────────────► Application
```

The Domain layer never depends on any external framework.

---

# 📦 Project Responsibilities

## NeoArchiveAI.Domain

Contains the business model.

Responsibilities

- Entities
- Enums
- Value Objects (future)
- Business Rules

Example

```text
User
Category
Document
EntityStatus
```

The Domain layer contains no database or framework code.

---

## NeoArchiveAI.Application

Contains all application use cases.

Responsibilities

- Commands
- Queries
- DTOs
- Validators
- Handlers
- Interfaces

Example

```text
CreateUser

↓

Validator

↓

Handler

↓

Repository Interface

↓

Response
```

Application defines WHAT should happen.

It never knows HOW it happens.

---

## NeoArchiveAI.Infrastructure

Provides implementations for the Application layer.

Responsibilities

- Entity Framework Core
- PostgreSQL
- Repositories
- Unit of Work
- Local Storage
- Hash Services
- External Services

Infrastructure knows how to access external resources.

---

## NeoArchiveAI.Api

Application entry point.

Responsibilities

- Controllers
- Dependency Injection
- Middleware
- Swagger
- Configuration

Controllers should remain thin.

Business logic belongs in the Application layer.

---

# 🔄 Request Flow

Every request follows the same pipeline.

```text
HTTP Request

        │

        ▼

Controller

        │

        ▼

Command / Query

        │

        ▼

Validator

        │

        ▼

Handler

        │

        ▼

Repository

        │

        ▼

Unit of Work

        │

        ▼

PostgreSQL

        │

        ▼

Response
```

---

# 💉 Dependency Injection

NeoArchiveAI uses ASP.NET Core Dependency Injection.

Handlers, repositories and services are registered during application startup.

Example

```text
Controller

↓

Handler

↓

Repository

↓

DbContext
```

This approach keeps the application loosely coupled.

---

# 📚 Repository Pattern

Repositories abstract data access.

Instead of querying Entity Framework directly, the Application layer communicates through repository interfaces.

Example

```text
Application

↓

IUserRepository

↓

UserRepository

↓

Entity Framework Core

↓

PostgreSQL
```

Benefits

- Loose coupling
- Easier testing
- Better maintainability

---

# 🔄 Unit of Work

The Unit of Work coordinates all database operations within a single transaction.

Example

```text
Create User

↓

Repository

↓

Repository

↓

Repository

↓

SaveChanges()
```

Benefits

- Transaction consistency
- Single commit
- Better control

---

# 🌊 Data Flow

```text
Client

↓

API

↓

Application

↓

Domain

↓

Infrastructure

↓

Database

↓

Infrastructure

↓

Application

↓

API

↓

Client
```

---

# 🎯 Design Principles

NeoArchiveAI follows:

- Clean Architecture
- SOLID
- Repository Pattern
- Unit of Work
- Dependency Injection
- Separation of Concerns
- Use Case Driven Development

---

# ✅ Benefits

The current architecture provides:

- Independent business rules
- High maintainability
- Scalability
- Testability
- Reusable components
- Low coupling
- High cohesion

---

# 🚀 Future Improvements

Planned architectural additions:

- JWT Authentication
- Refresh Tokens
- Role-Based Authorization
- File Storage
- OCR
- Artificial Intelligence
- Background Services
- Logging
- Health Checks
- Caching
- Event Bus

---

# 📄 License

This document is part of the NeoArchiveAI project and evolves together with the architecture.
