# 🐳 DOCKER

> **NeoArchiveAI Docker Guide**
>
> This document explains how to manage the Docker environment used by NeoArchiveAI during development.

---

# 📋 Table of Contents

- Overview
- Requirements
- Docker Compose
- Start Containers
- Stop Containers
- Restart Containers
- View Running Containers
- View Logs
- Enter Container
- Remove Containers
- Remove Volumes
- Common Commands
- Troubleshooting
- Development Workflow

---

# Overview

NeoArchiveAI uses Docker to provide a consistent development environment.

Currently, Docker is used to host:

- PostgreSQL

Future versions may include:

- Redis
- MinIO
- PgAdmin

---

# 📦 Requirements

Before starting, ensure you have installed:

- Docker Desktop
- Docker Compose

Verify the installation.

```bash
docker --version

docker compose version
```

---

# 🚀 Start Containers

Start all services.

```bash
docker compose up -d
```

Verify that the containers are running.

```bash
docker ps
```

---

# 🛑 Stop Containers

Stop all running services.

```bash
docker compose down
```

Containers will stop, but volumes will be preserved.

---

# 🔄 Restart Containers

Restart all services.

```bash
docker compose restart
```

Restart a specific container.

```bash
docker restart neoarchive-postgres
```

---

# 📋 View Running Containers

Show active containers.

```bash
docker ps
```

Show all containers.

```bash
docker ps -a
```

---

# 📄 View Logs

View PostgreSQL logs.

```bash
docker logs neoarchive-postgres
```

Follow logs in real time.

```bash
docker logs -f neoarchive-postgres
```

Show the last 100 lines.

```bash
docker logs --tail 100 neoarchive-postgres
```

---

# 🐘 Enter the PostgreSQL Container

Open an interactive shell.

```bash
docker exec -it neoarchive-postgres bash
```

Or connect directly to PostgreSQL.

```bash
docker exec -it neoarchive-postgres psql -U postgres
```

---

# 🗑 Remove Containers

Stop and remove containers.

```bash
docker compose down
```

Remove containers and anonymous volumes.

```bash
docker compose down -v
```

---

# 💾 Remove Volumes

Remove unused Docker volumes.

```bash
docker volume prune
```

> ⚠️ This permanently deletes unused Docker volumes.

---

# 🔧 Common Commands

Show Docker images.

```bash
docker images
```

Show Docker volumes.

```bash
docker volume ls
```

Show Docker networks.

```bash
docker network ls
```

Inspect a container.

```bash
docker inspect neoarchive-postgres
```

---

# 🛠 Troubleshooting

Container is not running.

```bash
docker ps -a
```

View container logs.

```bash
docker logs neoarchive-postgres
```

Restart the container.

```bash
docker restart neoarchive-postgres
```

Rebuild the environment.

```bash
docker compose down

docker compose up -d
```

---

# 🚀 Development Workflow

```text
Start Docker

      │
      ▼

Verify Containers

      │
      ▼

Run Application

      │
      ▼

Test with Swagger

      │
      ▼

Verify PostgreSQL

      │
      ▼

Stop Containers (Optional)
```

---

# 📄 License

This document is part of the NeoArchiveAI project and may evolve as additional Docker services are introduced.
