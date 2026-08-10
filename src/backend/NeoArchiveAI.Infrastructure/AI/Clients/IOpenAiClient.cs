using NeoArchiveAI.Infrastructure.AI.Models.OpenAI;
public interface IOpenAiClient
{
    Task<ChatResponse> SendAsync(
        ChatRequest request,
        CancellationToken cancellationToken = default);
}
