using System.Text.Json.Serialization;

namespace NeoArchiveAI.Infrastructure.AI.Models.OpenAI;

public sealed class Choice
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("message")]
    public ChatMessageResponse Message { get; set; } = new();
}
