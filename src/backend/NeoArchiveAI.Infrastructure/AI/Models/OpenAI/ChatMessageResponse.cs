using System.Text.Json.Serialization;

namespace NeoArchiveAI.Infrastructure.AI.Models.OpenAI;

public sealed class ChatMessageResponse
{
    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}
