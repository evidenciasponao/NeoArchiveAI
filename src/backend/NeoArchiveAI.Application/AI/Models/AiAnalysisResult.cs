namespace NeoArchiveAI.Application.AI.Models;

public sealed record AiAnalysisResult(
    string Summary,
    IReadOnlyList<string> Keywords,
    string SuggestedCategory,
    IReadOnlyList<string> Tags,
    decimal Confidence);
