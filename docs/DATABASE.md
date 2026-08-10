# 🗄️ DATABASE

> **NeoArchiveAI Database Documentation**
>
> This document describes the PostgreSQL database structure, Entity Framework Core workflow, and common database operations used by NeoArchiveAI.

---

# 📋 Table of Contents

- Database Overview
- Current Schema
- Docker
- PostgreSQL
- Entity Framework Core
- Common Queries
- OCR Verification
- Backup & Restore
- Useful Commands
- Database Notes
- Development Workflow

---

# 📊 Database Overview

Database Engine

- PostgreSQL

ORM

- Entity Framework Core

Migration Strategy

- Code First

Persistence

- Repository Pattern
- Unit of Work

Storage

- Local Storage
- SHA256 File Hash

---

# 🏛️ Current Schema

## Tables

| Table | Status |
|---------|--------|
| Documents | ✅ |
| Categories | ✅ |
| Users | ✅ |
| __EFMigrationsHistory | ✅ |

---

## Documents

Stores document metadata and OCR information.

Main fields

- Id
- Title
- Description
- FileName
- Extension
- MimeType
- Size
- StoragePath
- Hash
- ExtractedText
- CategoryId
- UploadedBy
- Status
- IsArchived
- CreatedAt
- UpdatedAt

---

## Categories

Stores document categories.

Main fields

- Id
- Name
- Description
- Status
- CreatedAt
- UpdatedAt

---

## Users

Stores application users.

Main fields

- Id
- FirstName
- LastName
- Email
- PasswordHash
- IsEmailConfirmed
- Status
- CreatedAt
- UpdatedAt

---

# 🐳 Docker

## Enter PostgreSQL container

```bash
docker exec -it neoarchive-postgres psql -U postgres
```

---

# 🗄️ PostgreSQL

## List databases

```sql
\l
```

---

## Connect to NeoArchiveAI

```sql
\c neoarchiveai
```

---

## Show tables

```sql
\dt
```

---

## Describe table

```sql
\d "Documents"
```

Example

```sql
\d "Users"
```

---

# 📄 Common Queries

## Documents

```sql
SELECT * FROM "Documents";
```

---

## Categories

```sql
SELECT * FROM "Categories";
```

---

## Users

```sql
SELECT * FROM "Users";
```

---

## Active records

```sql
SELECT *
FROM "Documents"
WHERE "Status" = 1;
```

---

## Deleted records

```sql
SELECT *
FROM "Documents"
WHERE "Status" = 2;
```

---

## OCR Verification

Verify extracted text.

```sql
SELECT
    "Title",
    "Extension",
    "ExtractedText"
FROM "Documents";
```

---

## Uploaded files

```sql
SELECT
    "Title",
    "StoragePath",
    "Hash"
FROM "Documents";
```

---

## File statistics

```sql
SELECT
    COUNT(*) AS TotalDocuments,
    SUM("Size") AS TotalBytes
FROM "Documents";
```

---

# 🧱 Entity Framework Core

Go to the Infrastructure project.

```bash
cd src/backend/NeoArchiveAI.Infrastructure
```

---

## Create migration

```bash
dotnet ef migrations add MigrationName \
    --startup-project ../NeoArchiveAI.Api
```

Example

```bash
dotnet ef migrations add AddExtractedText \
    --startup-project ../NeoArchiveAI.Api
```

---

## Apply migrations

```bash
dotnet ef database update \
    --startup-project ../NeoArchiveAI.Api
```

---

## Remove migration

```bash
dotnet ef migrations remove \
    --startup-project ../NeoArchiveAI.Api
```

---

## List migrations

```bash
dotnet ef migrations list \
    --startup-project ../NeoArchiveAI.Api
```

---

# 💾 Backup

Create backup

```bash
docker exec neoarchive-postgres \
pg_dump -U postgres neoarchiveai > neoarchiveai_backup.sql
```

---

# ♻️ Restore

Restore backup

```bash
docker exec -i neoarchive-postgres \
psql -U postgres neoarchiveai < neoarchiveai_backup.sql
```

---

# 🔍 Useful Commands

## Current database

```sql
SELECT current_database();
```

---

## PostgreSQL version

```sql
SELECT version();
```

---

## Connected user

```sql
SELECT current_user;
```

---

## Exit PostgreSQL

```sql
\q
```

---

# 📌 Database Notes

- PostgreSQL is the primary relational database.
- Entity Framework Core manages all schema changes.
- Migrations follow the Code First approach.
- Soft Delete is implemented through the `Status` column.
- Files are stored in Local Storage.
- SHA256 guarantees document integrity.
- OCR results are stored in the `ExtractedText` column.
- Every schema change must be versioned using EF Core migrations.

---

# 🚀 Development Workflow

```text
Modify Entity
      │
      ▼
Create Migration
      │
      ▼
Apply Migration
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
