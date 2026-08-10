# 🌐 API

> **NeoArchiveAI REST API Documentation**

Version: **v1**

This document describes the current REST API exposed by NeoArchiveAI.

---

# 📋 Table of Contents

- Overview
- Base URL
- Technology Stack
- Authentication
- Request & Response
- HTTP Status Codes
- Endpoints
- Validation
- File Upload
- OCR
- Postman
- Best Practices
- Future Improvements

---

# 📖 Overview

NeoArchiveAI exposes a RESTful API built with ASP.NET Core following Clean Architecture principles.

Current capabilities include:

- JWT Authentication
- Documents CRUD
- Categories CRUD
- Users CRUD
- Document Upload
- Document Download
- OCR Extraction

---

# 🌐 Base URL

Development

```text
http://localhost:5263/api
```

Production

```text
https://your-domain/api
```

---

# ⚙️ Technology Stack

- ASP.NET Core 10
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Clean Architecture
- Repository Pattern
- Unit Of Work
- FluentValidation
- Tesseract OCR

---

# 🔐 Authentication

NeoArchiveAI uses JWT Bearer Authentication.

Login

```http
POST /api/Auth/login
```

Example

```http
Authorization: Bearer <token>
```

All protected endpoints require a valid JWT.

---

# 📦 Request & Response

The API uses JSON for most requests and responses.

File uploads use:

```text
multipart/form-data
```

Example response

```json
{
    "id": "...",
    "title": "My Document"
}
```

---

# 📄 HTTP Status Codes

| Code | Meaning |
|------|---------|
| 200 | OK |
| 201 | Created |
| 204 | No Content |
| 400 | Bad Request |
| 401 | Unauthorized |
| 404 | Not Found |
| 500 | Internal Server Error |

---

# 🚀 Endpoints

## Authentication

| Method | Endpoint |
|---------|----------|
| POST | /api/Auth/login |

---

## Documents

| Method | Endpoint |
|---------|----------|
| GET | /api/Documents |
| GET | /api/Documents/{id} |
| POST | /api/Documents |
| PUT | /api/Documents/{id} |
| DELETE | /api/Documents/{id} |
| GET | /api/Documents/{id}/download |

---

## Categories

| Method | Endpoint |
|---------|----------|
| GET | /api/Categories |
| GET | /api/Categories/{id} |
| POST | /api/Categories |
| PUT | /api/Categories/{id} |
| DELETE | /api/Categories/{id} |

---

## Users

| Method | Endpoint |
|---------|----------|
| GET | /api/Users |
| GET | /api/Users/{id} |
| POST | /api/Users |
| PUT | /api/Users/{id} |
| DELETE | /api/Users/{id} |

---

## OCR

| Method | Endpoint |
|---------|----------|
| POST | /api/Ocr/{documentId} |

Extracts text from supported document formats using Tesseract OCR.

---

# ✅ Validation

Current validation includes:

- FluentValidation
- Domain validation
- Business rules
- Global Exception Middleware

---

# 📤 File Upload

Upload documents using:

```http
POST /api/Documents
```

Content-Type

```text
multipart/form-data
```

Uploaded files are:

- Stored in Local Storage
- Hashed using SHA256
- Registered in PostgreSQL

---

# 🔍 OCR

OCR endpoint

```http
POST /api/Ocr/{documentId}
```

Workflow

```text
Document

↓

Storage

↓

Tesseract

↓

ExtractedText

↓

PostgreSQL
```

Supported formats

- PNG
- JPG
- JPEG
- BMP
- TIFF
- PDF

---

# 📬 Postman

NeoArchiveAI is validated using Postman.

Typical workflow

```text
Login

↓

JWT

↓

Protected Endpoint

↓

PostgreSQL Verification
```

---

# 🎯 Best Practices

- Keep controllers thin
- Business logic belongs to Application
- Validate every request
- Use asynchronous operations
- Return appropriate HTTP status codes
- Follow REST conventions

---

# 🚀 Future Improvements

- OpenAI Integration
- Intelligent Search
- Refresh Tokens
- Role-Based Authorization
- API Versioning
- Rate Limiting
- Health Checks
- Serilog
- OpenTelemetry

---

# 📄 Notes

This document reflects the current API implementation and evolves together with the project.
