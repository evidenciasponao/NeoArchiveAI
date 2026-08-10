using NeoArchiveAI.Domain.Entities;

namespace NeoArchiveAI.Application.Abstractions.Services;

public interface IJwtService
{
    string GenerateToken(User user);

    DateTime GetExpiration();
}
