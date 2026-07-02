using System.Security.Cryptography;
using NeoArchiveAI.Application.Abstractions.Hashing;

namespace NeoArchiveAI.Infrastructure.Hashing;

public class Sha256HashService : IHashService
{
    public async Task<string> ComputeHashAsync(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        stream.Position = 0;

        using var sha256 = SHA256.Create();

        var hash = await sha256.ComputeHashAsync(stream, cancellationToken);

        stream.Position = 0;

        return Convert.ToHexString(hash);
    }
}