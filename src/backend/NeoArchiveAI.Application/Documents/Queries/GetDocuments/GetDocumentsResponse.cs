namespace NeoArchiveAI.Application.Documents.Queries.GetDocuments;

public sealed record GetDocumentsResponse(
    Guid Id,
    string Title,
    string FileName,
    string Extension,
    long Size,
    DateTime CreatedAt);