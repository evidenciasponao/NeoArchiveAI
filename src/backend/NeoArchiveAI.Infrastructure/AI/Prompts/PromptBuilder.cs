namespace NeoArchiveAI.Infrastructure.AI.Prompts;

public static class PromptBuilder
{
    public static string BuildDocumentAnalysisPrompt(
        string text)
    {
        return string.Format(
            PromptTemplates.AnalyzeDocument,
            text);
    }
}
