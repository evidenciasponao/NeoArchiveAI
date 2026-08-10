using NeoArchiveAI.Application.AI.Models;

namespace NeoArchiveAI.Application.Abstractions.Services;

public interface IAiService
{
    Task<AiAnalysisResult> AnalyzeTextAsync(
        string text,
        CancellationToken cancellationToken = default);
}
