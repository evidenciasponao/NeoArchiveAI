using NeoArchiveAI.Application.AI.Models;

namespace NeoArchiveAI.Application.AI.Commands.AnalyzeDocument;

public sealed record AnalyzeDocumentResponse(
    Guid DocumentId,
    AiAnalysisResult Analysis);
