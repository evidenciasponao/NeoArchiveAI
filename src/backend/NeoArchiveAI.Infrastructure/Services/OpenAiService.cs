using System.Text.Json;
using Microsoft.Extensions.Options;
using NeoArchiveAI.Application.Abstractions.Services;
using NeoArchiveAI.Application.AI.Models;
using NeoArchiveAI.Infrastructure.AI.Clients;
using NeoArchiveAI.Infrastructure.AI.Models.OpenAI;
using NeoArchiveAI.Infrastructure.AI.Prompts;
using NeoArchiveAI.Infrastructure.Configuration;

namespace NeoArchiveAI.Infrastructure.Services;

public sealed class OpenAiService : IAiService
{
    private readonly IOpenAiClient _client;
    private readonly AiOptions _options;

    public OpenAiService(
        IOpenAiClient client,
        IOptions<AiOptions> options)
    {
        _client = client;
        _options = options.Value;
    }

    public async Task<AiAnalysisResult> AnalyzeTextAsync(
        string text,
        CancellationToken cancellationToken = default)
    {
        var request = new ChatRequest
        {
            Model = _options.Model,
            Messages =
            [
                new ChatMessage
                {
                    Role = "user",
                    Content = PromptBuilder.BuildDocumentAnalysisPrompt(text)
                }
            ]
        };

        var response = await _client.SendAsync(
            request,
            cancellationToken);

        var content =
            response.Choices.FirstOrDefault()?.Message.Content
            ?? throw new InvalidOperationException(
                "OpenAI returned an empty response.");

        try
        {
            var result = JsonSerializer.Deserialize<AiAnalysisResult>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result
                ?? throw new InvalidOperationException(
                    "Unable to deserialize AI response.");
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"Invalid JSON returned by OpenAI.{Environment.NewLine}{content}",
                ex);
        }
    }
}
