namespace NeoArchiveAI.Application.Abstractions.Hashing;

public interface IHashService
{
    Task<string> ComputeHashAsync(
        Stream stream,
        CancellationToken cancellationToken = default);
}