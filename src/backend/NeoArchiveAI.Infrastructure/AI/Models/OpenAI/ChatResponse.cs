using System.Text.Json.Serialization;

namespace NeoArchiveAI.Infrastructure.AI.Models.OpenAI;

public sealed class ChatResponse
{
    [JsonPropertyName("choices")]
    public List<Choice> Choices { get; set; } = [];
}
