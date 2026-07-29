# 🗄️ DATABASE

This document describes how to work with the PostgreSQL database used by **NeoArchiveAI**.

---

# 📋 Contents

- Connect to the PostgreSQL container
- Access the database
- Query data
- Create migrations
- Apply migrations
- Remove migrations
- Create backups
- Restore backups
- Useful commands

---

# 🐳 Docker

## Enter the PostgreSQL container

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

## Connect to NeoArchiveAI database

```sql
\c neoarchiveai
```

Expected output:

```text
You are now connected to database "neoarchiveai".
```

---

## List tables

```sql
\dt
```

---

## Describe a table

```sql
\d "Documents"
```

Example:

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

## View active records only

Documents

```sql
SELECT *
FROM "Documents"
WHERE "Status" = 1;
```

Categories

```sql
SELECT *
FROM "Categories"
WHERE "Status" = 1;
```

Users

```sql
SELECT *
FROM "Users"
WHERE "Status" = 1;
```

---

## View deleted records (Soft Delete)

Documents

```sql
SELECT *
FROM "Documents"
WHERE "Status" = 2;
```

Categories

```sql
SELECT *
FROM "Categories"
WHERE "Status" = 2;
```

Users

```sql
SELECT *
FROM "Users"
WHERE "Status" = 2;
```

---

# 🧱 Entity Framework Core

Go to Infrastructure project.

```bash
cd src/backend/NeoArchiveAI.Infrastructure
```

---

## Create migration

```bash
dotnet ef migrations add MigrationName \
    --startup-project ../NeoArchiveAI.Api
```

Example:

```bash
dotnet ef migrations add AddAuthentication \
    --startup-project ../NeoArchiveAI.Api
```

---

## Apply migrations

```bash
dotnet ef database update \
    --startup-project ../NeoArchiveAI.Api
```

---

## Remove last migration

> Only if the migration has not been applied.

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

Create a backup.

```bash
docker exec neoarchive-postgres \
pg_dump -U postgres neoarchiveai > neoarchiveai_backup.sql
```

---

# ♻️ Restore

Restore a backup.

```bash
docker exec -i neoarchive-postgres \
psql -U postgres neoarchiveai < neoarchiveai_backup.sql
```

---

# 🔍 Useful Commands

## Show current database

```sql
SELECT current_database();
```

---

## Show PostgreSQL version

```sql
SELECT version();
```

---

## Show connected user

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
- Entity Framework Core manages migrations.
- Soft Delete is implemented using the `Status` column.
- Docker is the recommended development environment.
- Database schema changes should always be versioned through EF Core migrations.

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
Swagger Testing
      │
      ▼
PostgreSQL Verification
      │
      ▼
Git Commit
```
