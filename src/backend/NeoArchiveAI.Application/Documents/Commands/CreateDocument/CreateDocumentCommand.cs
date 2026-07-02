namespace NeoArchiveAI.Application.Documents.Commands.CreateDocument;

public sealed record CreateDocumentCommand(
    Stream FileStream,
    string FileName,
    string MimeType,
    string Title,
    string Description,
    Guid CategoryId,
    Guid UploadedBy);