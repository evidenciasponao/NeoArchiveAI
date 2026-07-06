namespace NeoArchiveAI.Application.Users.Commands.CreateUser;

public sealed record CreateUserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsEmailConfirmed);