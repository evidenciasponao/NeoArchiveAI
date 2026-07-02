# API Documentation

> **NeoArchiveAI REST API**
>
> Version: **v1**
>
> This document describes the REST API exposed by NeoArchiveAI. It is intended for developers who want to integrate, consume, or extend the platform.

---

# Table of Contents

* Overview
* Base URL
* API Versioning
* Technology Stack
* Authentication
* Authorization
* Request Format
* Response Format
* HTTP Status Codes
* Error Handling
* API Conventions
* Endpoints
* Pagination
* Filtering
* Sorting
* Validation
* File Uploads
* Rate Limiting
* Swagger / OpenAPI
* Postman Collection
* cURL Examples
* C# Examples
* JavaScript Examples
* Best Practices
* Future Improvements

---

# Overview

NeoArchiveAI exposes a RESTful API built with ASP.NET Core following Clean Architecture principles.

The API is responsible for:

* Managing digital documents.
* Organizing files.
* Handling metadata.
* Providing a scalable backend.
* Serving client applications.

The API is stateless.

Every request must contain all the information required to process it.

---

# Base URL

Development

```text
https://localhost:5001/api
```

Production

```text
https://your-domain.com/api
```

Future versions may include:

```text
/api/v1
/api/v2
```

---

# API Versioning

Current Version

```
v1
```

Future versions will follow Microsoft's API Versioning recommendations.

Example

```http
GET /api/v1/documents
```

---

# Technology Stack

The API is built with:

* ASP.NET Core
* Entity Framework Core
* SQL Server
* Clean Architecture
* Repository Pattern
* Dependency Injection
* Swagger / OpenAPI

Future technologies

* Redis
* Docker
* Serilog
* xUnit
* FluentValidation
* JWT Authentication
* GitHub Actions

---

# Authentication

Current Status

Authentication is not required during the initial MVP.

Future Implementation

The API will support:

* JWT Bearer Authentication
* Refresh Tokens
* Role-Based Authorization
* Claims-Based Authorization

Example

```http
Authorization: Bearer <token>
```

---

# Authorization

Future roles may include:

| Role          | Permissions   |
| ------------- | ------------- |
| Administrator | Full access   |
| User          | Read / Upload |
| Auditor       | Read Only     |

---

# Request Format

All requests use JSON.

Example

```json
{
    "title": "My Document",
    "description": "Example",
    "categoryId": 2
}
```

Content-Type

```http
application/json
```

---

# Response Format

Successful responses

```json
{
    "success": true,
    "message": "Operation completed successfully.",
    "data": {}
}
```

Error responses

```json
{
    "success": false,
    "message": "Validation failed.",
    "errors": []
}
```

---

# HTTP Status Codes

| Code | Meaning               |
| ---- | --------------------- |
| 200  | OK                    |
| 201  | Created               |
| 204  | No Content            |
| 400  | Bad Request           |
| 401  | Unauthorized          |
| 403  | Forbidden             |
| 404  | Not Found             |
| 409  | Conflict              |
| 422  | Validation Error      |
| 500  | Internal Server Error |

---

# Error Handling

Example

```json
{
    "success": false,
    "message": "Document not found."
}
```

Validation Example

```json
{
    "success": false,
    "errors": [
        "Title is required.",
        "CategoryId is invalid."
    ]
}
```

---

# API Conventions

HTTP Verbs

| Verb   | Description    |
| ------ | -------------- |
| GET    | Read           |
| POST   | Create         |
| PUT    | Update         |
| PATCH  | Partial Update |
| DELETE | Delete         |

Naming Convention

* camelCase for JSON
* PascalCase in C#
* REST resource naming
* Plural endpoints

Example

```
/documents
/categories
/files
```

---

# Endpoints

## Documents

### Get all documents

```http
GET /documents
```

Response

```json
[
    {
        "id":1,
        "title":"First Document"
    }
]
```

---

### Get document by Id

```http
GET /documents/{id}
```

---

### Create document

```http
POST /documents
```

Body

```json
{
    "title":"My Document",
    "description":"Description"
}
```

---

### Update document

```http
PUT /documents/{id}
```

---

### Delete document

```http
DELETE /documents/{id}
```

---

## Categories

Example

```http
GET /categories
```

---

## Files

Example

```http
GET /files
```

---

# Pagination

Future implementation

Example

```http
GET /documents?page=1&pageSize=20
```

Response

```json
{
    "page":1,
    "pageSize":20,
    "totalItems":125,
    "totalPages":7,
    "items":[]
}
```

---

# Filtering

Example

```http
GET /documents?category=Invoices
```

Multiple filters

```http
GET /documents?category=Invoices&year=2026
```

---

# Sorting

Ascending

```http
GET /documents?sort=title
```

Descending

```http
GET /documents?sort=-createdAt
```

---

# Validation

Current validation

* Required fields
* Maximum length
* Data type validation

Future validation

* FluentValidation
* Business Rules
* Domain Validation

---

# File Uploads

Future endpoint

```http
POST /documents/upload
```

Multipart request

```text
multipart/form-data
```

Supported formats

* PDF
* DOCX
* XLSX
* PNG
* JPG

Future

* AI indexing
* OCR
* Metadata extraction

---

# Rate Limiting

Future implementation

Example

```
100 requests / minute
```

Responses

```
429 Too Many Requests
```

---

# Swagger / OpenAPI

Swagger will be available at

```text
https://localhost:5001/swagger
```

Production

```text
https://your-domain.com/swagger
```

---

# Postman Collection

A Postman Collection will be included in future releases.

Recommended folders

* Documents
* Categories
* Files

---

# cURL Examples

Get Documents

```bash
curl https://localhost:5001/api/documents
```

Create Document

```bash
curl -X POST \
-H "Content-Type: application/json" \
-d '{"title":"Example"}' \
https://localhost:5001/api/documents
```

---

# C# Examples

```csharp
HttpClient client = new HttpClient();

var response = await client.GetAsync(
    "https://localhost:5001/api/documents");

string json = await response.Content.ReadAsStringAsync();
```

---

# JavaScript Examples

```javascript
const response = await fetch("/api/documents");

const data = await response.json();
```

POST Example

```javascript
await fetch("/api/documents",{
    method:"POST",
    headers:{
        "Content-Type":"application/json"
    },
    body:JSON.stringify({
        title:"Example"
    })
});
```

---

# Best Practices

* Always validate input.
* Use HTTPS.
* Handle errors properly.
* Never expose internal exceptions.
* Keep endpoints RESTful.
* Return appropriate status codes.
* Use asynchronous operations.
* Follow SOLID principles.
* Keep controllers thin.
* Place business logic in the Application layer.

---

# Future Improvements

The API roadmap includes:

* JWT Authentication
* Refresh Tokens
* Role-Based Authorization
* FluentValidation
* xUnit Tests
* Integration Tests
* Redis Cache
* Docker Support
* Background Services
* Health Checks
* API Versioning
* Logging with Serilog
* OpenTelemetry
* CI/CD Pipeline
* Azure Deployment
* Kubernetes Support
* AI-powered document indexing
* OCR integration
* Semantic Search
* Full-text search
* ElasticSearch integration

---

# License

This documentation is part of the NeoArchiveAI project and may evolve as new features are introduced.

Contributions and improvements are welcome.
