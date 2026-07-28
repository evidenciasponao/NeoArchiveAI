using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserResponse(
    UserDto User);
