using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Abstractions.Services;
using NeoArchiveAI.Application.Exceptions;

namespace NeoArchiveAI.Application.AI.Commands.AnalyzeDocument;

public sealed class AnalyzeDocumentHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IAiService _aiService;

    public AnalyzeDocumentHandler(
        IDocumentRepository documentRepository,
        IAiService aiService)
    {
        _documentRepository = documentRepository;
        _aiService = aiService;
    }

    public async Task<AnalyzeDocumentResponse> Handle(
        AnalyzeDocumentCommand command,
        CancellationToken cancellationToken)
    {
        var document = await _documentRepository.GetByIdAsync(
            command.DocumentId);

        if (document is null)
        {
            throw new NotFoundException(
                "Document not found.");
        }

        if (string.IsNullOrWhiteSpace(document.ExtractedText))
        {
            throw new ValidationException(
                new Dictionary<string, string[]>
                {
                    {
                        nameof(command.DocumentId),
                        new[]
                        {
                            "The document has no extracted OCR text."
                        }
                    }
                });
        }

        var analysis =
            await _aiService.AnalyzeTextAsync(
                document.ExtractedText,
                cancellationToken);

        return new AnalyzeDocumentResponse(
            document.Id,
            analysis);
    }
}
