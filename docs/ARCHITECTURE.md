# 🏛 ARCHITECTURE

> **NeoArchiveAI Architecture Documentation**

This document describes the architecture, project responsibilities and design principles used throughout NeoArchiveAI.

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
- Document Processing Pipeline
- Design Principles
- Benefits

---

# 📖 Overview

NeoArchiveAI follows **Clean Architecture**.

The main objective is to keep business rules independent from frameworks, databases and external services.

Current architecture includes:

- ASP.NET Core
- PostgreSQL
- Entity Framework Core
- JWT Authentication
- Local Storage
- SHA256
- OCR (Tesseract)

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

```text
                Clients
          (Postman / Angular)

                    │
                    ▼

             ASP.NET Core API

                    │
                    ▼

        Application Layer
     (Commands / Queries)

                    │
                    ▼

          Domain Layer
       (Business Rules)

                    │
                    ▼

      Infrastructure Layer

 ┌─────────────┬─────────────┬─────────────┐
 │ PostgreSQL  │ LocalStorage│ Tesseract   │
 └─────────────┴─────────────┴─────────────┘
```

Dependencies always point toward the Domain.

---

# 📦 Project Responsibilities

## Domain

Contains business rules.

Responsibilities

- Entities
- Enums
- Business Rules

---

## Application

Contains application use cases.

Responsibilities

- Commands
- Queries
- Handlers
- Validators
- Responses
- Interfaces

Application defines **what** the system does.

---

## Infrastructure

Contains implementations.

Responsibilities

- Entity Framework Core
- PostgreSQL
- Repository Pattern
- Unit Of Work
- Local Storage
- SHA256 Hash Service
- JWT Service
- Password Hasher
- OCR Service (Tesseract)

Infrastructure defines **how** operations are performed.

---

## API

Application entry point.

Responsibilities

- Controllers
- Middleware
- Dependency Injection
- Authentication
- Swagger

Controllers remain thin.

Business logic belongs in Application.

---

# 🔄 Request Flow

Every request follows the same structure.

```text
HTTP Request

↓

Controller

↓

Command / Query

↓

Validator

↓

Handler

↓

Repository

↓

Storage / Services

↓

Unit Of Work

↓

PostgreSQL

↓

Response
```

---

# 💉 Dependency Injection

NeoArchiveAI uses ASP.NET Core Dependency Injection.

```text
Controller

↓

Handler

↓

Repository

↓

DbContext
```

All implementations are registered during application startup.

---

# 📚 Repository Pattern

Repositories abstract data access.

```text
Application

↓

IDocumentRepository

↓

DocumentRepository

↓

Entity Framework Core

↓

PostgreSQL
```

The Application layer never depends directly on Entity Framework.

---

# 🔄 Unit of Work

The Unit Of Work coordinates database transactions.

```text
Repository

↓

Repository

↓

Repository

↓

SaveChanges()
```

Benefits

- Single transaction
- Consistency
- Better control

---

# 📄 Document Processing Pipeline

```text
Upload Document

↓

SHA256

↓

Local Storage

↓

PostgreSQL

↓

Download

↓

OCR (Tesseract)

↓

ExtractedText

↓

OpenAI (Next)

↓

Intelligent Search (Next)
```

---

# 🎯 Design Principles

NeoArchiveAI follows:

- Clean Architecture
- SOLID Principles
- Repository Pattern
- Unit Of Work
- Dependency Injection
- CQRS (Simple)
- Separation of Concerns
- Use Case Driven Development

---

# ✅ Benefits

Current architecture provides:

- Low coupling
- High cohesion
- Independent business rules
- Testable use cases
- Replaceable infrastructure services
- Scalable architecture
- Enterprise-ready foundation

---

# 📄 Notes

This document evolves together with the architecture of NeoArchiveAI.
