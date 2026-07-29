# 🚀 INSTALL

> **NeoArchiveAI Installation Guide**
>
> This document explains how to install, configure, and run NeoArchiveAI in a local development environment.

---

# 📋 Table of Contents

- Overview
- Requirements
- Clone Repository
- Restore Packages
- Configure Environment
- Start Docker
- Apply Migrations
- Run the API
- Verify Installation
- Access Swagger
- Verify PostgreSQL
- Troubleshooting
- Development Workflow

---

# Overview

This guide walks through the complete installation process for NeoArchiveAI.

After completing these steps, you will have:

- PostgreSQL running in Docker
- Database created
- Entity Framework Core migrations applied
- ASP.NET Core API running
- Swagger available for testing

---

# 💻 Requirements

Before starting, install the following tools:

- .NET 10 SDK
- Docker Desktop
- Git
- Visual Studio 2022 or Visual Studio Code

Verify the installation.

```bash
dotnet --version

docker --version

docker compose version

git --version
```

---

# 📥 Clone Repository

Clone the project.

```bash
git clone https://github.com/your-user/NeoArchiveAI.git
```

Enter the project directory.

```bash
cd NeoArchiveAI
```

---

# 📦 Restore Packages

Restore all NuGet packages.

```bash
dotnet restore
```

---

# ⚙️ Configure Environment

Review the configuration file.

```text
src/backend/NeoArchiveAI.Api/appsettings.Development.json
```

Verify:

- PostgreSQL connection string
- Database name
- Other development settings

---

# 🐳 Start Docker

Start the PostgreSQL container.

```bash
docker compose up -d
```

Verify that the container is running.

```bash
docker ps
```

Expected container:

```text
neoarchive-postgres
```

---

# 🗄️ Apply Migrations

Navigate to the Infrastructure project.

```bash
cd src/backend/NeoArchiveAI.Infrastructure
```

Apply the database migrations.

```bash
dotnet ef database update \
    --startup-project ../NeoArchiveAI.Api
```

If successful, the database schema will be created automatically.

---

# ▶️ Run the API

Navigate to the API project.

```bash
cd ../NeoArchiveAI.Api
```

Run the application.

```bash
dotnet run
```

The console should indicate that the application is running.

Example:

```text
Now listening on:
https://localhost:5001
```

---

# ✅ Verify Installation

Confirm that:

- Docker container is running
- Database exists
- Tables were created
- API starts successfully
- Swagger is accessible

---

# 📖 Access Swagger

Open your browser.

```text
https://localhost:5001/swagger
```

Swagger should display all available endpoints.

---

# 🐘 Verify PostgreSQL

Connect to the PostgreSQL container.

```bash
docker exec -it neoarchive-postgres psql -U postgres
```

Connect to the database.

```sql
\c neoarchiveai
```

List tables.

```sql
\dt
```

Expected tables include:

```text
Categories
Documents
Users
__EFMigrationsHistory
```

Exit PostgreSQL.

```sql
\q
```

---

# 🛠 Troubleshooting

## Docker container is not running

```bash
docker compose up -d
```

---

## Verify container status

```bash
docker ps
```

---

## View PostgreSQL logs

```bash
docker logs neoarchive-postgres
```

---

## Reapply migrations

```bash
dotnet ef database update \
    --startup-project ../NeoArchiveAI.Api
```

---

## Restore NuGet packages

```bash
dotnet restore
```

---

## Rebuild the solution

```bash
dotnet build
```

---

# 🚀 Development Workflow

```text
Clone Repository

      │
      ▼

Restore Packages

      │
      ▼

Start Docker

      │
      ▼

Apply Migrations

      │
      ▼

Run API

      │
      ▼

Open Swagger

      │
      ▼

Verify PostgreSQL

      │
      ▼

Start Development
```

---

# 📄 License

This document is part of the NeoArchiveAI project and describes the recommended installation process for local development.
