namespace NeoArchiveAI.Infrastructure.AI.Models.OpenAI;

public sealed class ChatRequest
{
    public string Model { get; set; } = string.Empty;

    public List<ChatMessage> Messages { get; set; } = [];
}
