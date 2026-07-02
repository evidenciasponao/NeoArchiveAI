namespace NeoArchiveAI.Application.Documents.Commands.CreateDocument;

public sealed record CreateDocumentResponse(
    Guid Id,
    string Title,
    string FileName,
    string StoragePath);
