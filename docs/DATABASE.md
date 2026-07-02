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

Salir

\q

Cómo consultar tablas.
Cómo hacer backups.
Cómo restaurar la base.
Comandos útiles.