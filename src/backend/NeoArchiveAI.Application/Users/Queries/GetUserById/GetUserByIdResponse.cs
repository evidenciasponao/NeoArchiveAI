using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Users.Queries.GetUserById;

public sealed record GetUserByIdResponse(
    UserDto User);
