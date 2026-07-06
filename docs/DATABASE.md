Aquí documentaremos:

Cómo conectarse al contenedor.
Cómo entrar a PostgreSQL.
PostgreSQL

Entrar al contenedor

docker exec -it neoarchive-postgres psql -U postgres

Listar bases de datos

\l

Entrar a la base

\c neoarchiveai

Ver tablas

\dt

Consultar documentos

SELECT * FROM "Documents";

Consultar categorias

SELECT * FROM "Categories";

Salir

\q

Cómo consultar tablas.
Cómo hacer backups.
Cómo restaurar la base.
Comandos útiles.


# Crear migración
cd src/backend/NeoArchiveAI.Infrastructure

dotnet ef migrations add NombreMigracion \
    --startup-project ../NeoArchiveAI.Api

# Aplicar migraciones
dotnet ef database update \
    --startup-project ../NeoArchiveAI.Api

# Eliminar última migración (si aún no se aplicó)
dotnet ef migrations remove \
    --startup-project ../NeoArchiveAI.Api