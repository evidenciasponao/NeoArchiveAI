# 🤝 CONTRIBUTING

> **NeoArchiveAI Development Guide**
>
> This document defines the development workflow and coding standards used throughout the NeoArchiveAI project.

---

# 📋 Table of Contents

- Overview
- Development Workflow
- New Use Case
- Folder Structure
- Coding Standards
- Validation Process
- Git Workflow
- Documentation
- Best Practices

---

# Overview

NeoArchiveAI follows a **Use Case Driven Development** approach.

Every feature is implemented using the same workflow to guarantee consistency across the solution.

The objective is to:

- Keep the architecture consistent.
- Reduce technical debt.
- Improve maintainability.
- Simplify future development.

---

# 🚀 Development Workflow

Every feature follows the same process.

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
      │
      ▼
Git Push
      │
      ▼
Roadmap Update
```

---

# 📦 New Use Case

Every new Use Case must follow these steps.

```text
New Use Case

↓

1. Create Folder

2. Command / Query

3. Validator

4. Response (if applicable)

5. Handler

6. Register Dependency Injection

7. Request (if applicable)

8. Controller

9. Build

10. Swagger Testing

11. PostgreSQL Verification

12. Git Commit

13. Git Push

14. Update Roadmap
```

Every step must be completed before moving to the next one.

---

# 📁 Folder Structure

Before creating a new file, inspect the existing project structure.

Example

```text
NeoArchiveAI.Api

│
├── Controllers
├── Requests
├── Responses
└── ...
```

Never assume namespaces, folder names, or existing classes.

Always inspect the project first.

---

# 🏗 Feature Development

Every feature should follow the project architecture.

```text
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

Unit of Work

↓

Database
```

Business rules belong in the Domain layer.

Application coordinates the use case.

Infrastructure implements external services.

API exposes endpoints.

---

# 📐 Coding Standards

The project follows these conventions.

- One responsibility per class.
- Thin Controllers.
- Business logic inside Handlers and Domain.
- Dependency Injection for every service.
- Asynchronous operations whenever possible.
- Use records for Commands, Queries and Responses.
- Validate input using FluentValidation.
- Never access Entity Framework directly from Controllers.

---

# ✅ Validation Process

Every feature must be validated before being completed.

### Build

```bash
dotnet build
```

The solution must compile without errors.

---

### Swagger

Verify:

- Request
- Response
- Status Codes
- Error Handling

---

### PostgreSQL

Verify:

- Data persistence
- Updates
- Soft Delete
- Relationships

---

# 🌱 Git Workflow

Every completed feature must be versioned.

```bash
git add .

git commit -m "feat(module): description"

git push
```

Commit messages should follow the Conventional Commits specification.

Examples

```text
feat(users): complete Users CRUD

feat(auth): implement login endpoint

fix(documents): validate title length

refactor(application): simplify handlers
```

---

# 📚 Documentation

After completing a feature, update the corresponding documentation.

Possible documents include:

- README.md
- ROADMAP.md
- API.md
- DATABASE.md
- ARCHITECTURE.md
- DOCKER.md
- CONTRIBUTING.md

Documentation should always reflect the current state of the project.

---

# 💡 Best Practices

- Build after every completed file.
- Never continue if the project does not compile.
- Validate every endpoint using Swagger.
- Verify changes directly in PostgreSQL.
- Commit only validated features.
- Keep documentation updated.
- Prefer consistency over speed.
- Never skip the development workflow.

---

# 📄 License

This document is part of the NeoArchiveAI project and defines the official development workflow.
