namespace NeoArchiveAI.Infrastructure.Configuration;

public sealed class AiOptions
{
    public const string SectionName = "Ai";

    public string ApiKey { get; init; } = string.Empty;

    public string Model { get; init; } = "gpt-5-mini";

    public string BaseUrl { get; init; } = "https://api.openai.com/v1/";
}
