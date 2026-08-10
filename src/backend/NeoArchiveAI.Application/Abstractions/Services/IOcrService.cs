namespace NeoArchiveAI.Application.Abstractions.Services;

public interface IOcrService
{
    Task<string> ExtractTextAsync(
        Stream stream,
        CancellationToken cancellationToken = default);
}
