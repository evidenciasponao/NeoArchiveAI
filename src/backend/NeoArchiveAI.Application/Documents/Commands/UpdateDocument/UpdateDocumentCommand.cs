namespace NeoArchiveAI.Application.Documents.Commands.UpdateDocument;

public sealed record UpdateDocumentCommand(
    Guid Id,
    string Title,
    string Description,
    Guid CategoryId);