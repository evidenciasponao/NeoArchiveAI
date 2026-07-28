namespace NeoArchiveAI.Application.Users.DTOs;

public sealed record UserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsEmailConfirmed);
