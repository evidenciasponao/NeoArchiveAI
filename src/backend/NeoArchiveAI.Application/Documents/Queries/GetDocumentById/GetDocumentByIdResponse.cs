namespace NeoArchiveAI.Application.Documents.Queries.GetDocumentById;

public sealed record GetDocumentByIdResponse(
    Guid Id,
    string Title,
    string Description,
    string FileName,
    string Extension,
    string MimeType,
    long Size,
    string StoragePath,
    string Hash,
    Guid CategoryId,
    Guid UploadedBy);