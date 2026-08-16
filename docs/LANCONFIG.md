# LANCONFIG — Ejecución de NeoArchiveAI en Red Local

## Objetivo

Este documento describe cómo ejecutar NeoArchiveAI en una red local (LAN), permitiendo acceder a la aplicación desde un PC y dispositivos móviles conectados a la misma red.

La configuración actual permite ejecutar Angular y ASP.NET Core sobre el servidor Ubuntu y consumir la aplicación desde un navegador mediante la IP local del servidor.

---

## Arquitectura LAN actual

```text
                 RED LOCAL / Wi-Fi
                        │
          ┌─────────────┴─────────────┐
          │                           │
       💻 PC                      📱 Android
          │                           │
          └─────────────┬─────────────┘
                        │
                Ubuntu Server
                 192.168.1.28
                        │
             ┌──────────┴──────────┐
             │                     │
       Angular :4200         ASP.NET Core :5263
             │                     │
             └──────────┬──────────┘
                        │
                    PostgreSQL
```

---

## Requisitos

- Ubuntu Server ejecutándose.
- Angular instalado.
- .NET SDK instalado.
- PostgreSQL disponible.
- PC y dispositivos cliente conectados a la misma red local.
- Conocer la IP LAN del servidor Ubuntu.

La IP utilizada durante las pruebas fue:

```text
192.168.1.28
```

> La IP puede cambiar dependiendo de la configuración de la red. Si cambia, deben actualizarse las URLs utilizadas por el frontend y las políticas CORS del backend.

---

# 1. Backend — ASP.NET Core

### Ruta

```bash
~/projects/NeoArchiveAI/src/backend/NeoArchiveAI.Api
```

### Iniciar API

```bash
cd ~/projects/NeoArchiveAI/src/backend/NeoArchiveAI.Api
dotnet run --urls "http://0.0.0.0:5263"
```

El servidor debe quedar escuchando en:

```text
0.0.0.0:5263
```

Esto permite aceptar conexiones provenientes de otros dispositivos de la red local.

### Verificar puerto

Desde otra terminal:

```bash
ss -lntp | grep 5263
```

Resultado esperado:

```text
0.0.0.0:5263
```

---

# 2. Frontend — Angular

### Ruta

```bash
~/projects/NeoArchiveAI/src/frontend/NeoArchiveAI.Web
```

### Iniciar Angular

Abrir una segunda terminal SSH y ejecutar:

```bash
cd ~/projects/NeoArchiveAI/src/frontend/NeoArchiveAI.Web
ng serve --host 0.0.0.0 --port 4200
```

Angular debe quedar disponible en:

```text
0.0.0.0:4200
```

Desde un dispositivo conectado a la misma red:

```text
http://192.168.1.28:4200
```

---

# 3. Configuración de comunicación

El frontend utiliza la IP LAN del servidor para comunicarse con la API:

```text
http://192.168.1.28:5263
```

La API utiliza CORS para permitir el frontend LAN:

```text
http://192.168.1.28:4200
```

También se mantiene:

```text
http://localhost:4200
```

para las pruebas realizadas directamente desde el servidor/PC.

---

# 4. Pruebas realizadas

La integración LAN fue validada mediante:

- Login desde PC.
- Login desde Android.
- Autenticación JWT.
- Navegación al Dashboard.
- Consulta de documentos.
- Consulta de detalles de documentos.
- Visualización de datos provenientes del backend.
- Comunicación Angular → ASP.NET Core → PostgreSQL.
- Pruebas desde navegador móvil mediante Wi-Fi.

---

# 5. Ejecución diaria

Para levantar el sistema desde cero:

### Terminal 1 — Backend

```bash
cd ~/projects/NeoArchiveAI/src/backend/NeoArchiveAI.Api
dotnet run --urls "http://0.0.0.0:5263"
```

### Terminal 2 — Frontend

```bash
cd ~/projects/NeoArchiveAI/src/frontend/NeoArchiveAI.Web
ng serve --host 0.0.0.0 --port 4200
```

### Cliente PC

```text
http://localhost:4200
```

o, si se desea probar mediante la IP LAN:

```text
http://192.168.1.28:4200
```

### Cliente Android

```text
http://192.168.1.28:4200
```

El dispositivo Android debe estar conectado a la misma red que el servidor.

---

# 6. Ventaja de la arquitectura LAN

NeoArchiveAI puede funcionar como una aplicación cliente-servidor dentro de una red local sin depender obligatoriamente de servicios cloud para sus funciones principales.

Esto permite escenarios como:

- Oficinas.
- Entidades con infraestructura local.
- Redes internas.
- Laboratorios.
- Entornos de prueba.
- Servidores privados.
- Instalaciones donde no se desea exponer documentos a Internet.

El servidor puede alojar:

```text
Angular
ASP.NET Core API
PostgreSQL
Almacenamiento de documentos
```

y los clientes pueden acceder desde navegadores de escritorio o dispositivos móviles.

---

# 7. OCR e inteligencia artificial

La arquitectura también permite evolucionar hacia un escenario completamente local.

Para que el OCR funcione sin servicios cloud, el motor OCR debe ejecutarse localmente o dentro de un servicio disponible en la misma red.

Por ejemplo:

```text
Android / PC
      │
      ▼
 Angular
      │
      ▼
 ASP.NET Core
      │
      ├── PostgreSQL
      ├── File Storage
      └── OCR local
```

De esta manera, los documentos podrían procesarse sin necesidad de enviarlos a un proveedor externo.

La disponibilidad de esta modalidad dependerá de que el componente OCR/IA utilizado sea local y esté configurado dentro de la infraestructura.

---

# 8. Siguiente evolución

La configuración LAN constituye una base para continuar con:

1. Upload de documentos desde Android.
2. Procesamiento OCR local.
3. Clasificación automática.
4. Análisis mediante IA.
5. Gestión de categorías.
6. Usuarios y permisos.
7. Administración de almacenamiento.
8. Despliegue posterior en Azure u otro proveedor cloud.

La misma aplicación puede evolucionar desde:

```text
LAN
 ↓
Servidor privado
 ↓
Cloud
```

sin cambiar necesariamente la arquitectura principal del sistema.

---

## Estado

**LAN Integration: COMPLETADO**

Fecha de validación:

```text
2026-08-16
```

Cliente validado:

```text
PC / Navegador
Android / Navegador móvil
```

Servidor:

```text
Ubuntu Server
192.168.1.28
```

Puertos:

```text
Angular      4200
ASP.NET Core 5263
```
