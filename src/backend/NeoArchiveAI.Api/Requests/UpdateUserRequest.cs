namespace NeoArchiveAI.Api.Requests.Users;

public sealed record UpdateUserRequest(
    string FirstName,
    string LastName,
    string Email);
