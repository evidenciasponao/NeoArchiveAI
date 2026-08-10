namespace NeoArchiveAI.Infrastructure.AI.Prompts;

public static class PromptTemplates
{
    public const string AnalyzeDocument =
"""
You are an AI specialized in enterprise document analysis.

Analyze the following document.

Return ONLY a valid JSON object.

The JSON must have exactly this structure:

{{
  "summary": "...",
  "keywords": [],
  "suggestedCategory": "...",
  "tags": [],
  "confidence": 0
}}

Document:

{0}
""";
}
