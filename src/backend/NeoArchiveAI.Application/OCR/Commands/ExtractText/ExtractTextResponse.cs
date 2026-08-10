namespace NeoArchiveAI.Application.OCR.Commands.ExtractText;

public sealed record ExtractTextResponse(
    Guid DocumentId,
    string ExtractedText);
