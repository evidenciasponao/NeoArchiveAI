namespace NeoArchiveAI.Infrastructure.AI.Models.OpenAI;

public sealed class ChatMessage
{
    public string Role { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
