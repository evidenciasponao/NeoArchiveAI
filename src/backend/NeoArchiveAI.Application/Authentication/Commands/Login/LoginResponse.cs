using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Authentication.Commands.Login;

public sealed record LoginResponse(
    string AccessToken,
    DateTime ExpiresAt,
    UserDto User);
