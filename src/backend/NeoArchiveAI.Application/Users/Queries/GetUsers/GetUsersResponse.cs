using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Users.Queries.GetUsers;

public sealed record GetUsersResponse(
    IReadOnlyCollection<UserDto> Users);
