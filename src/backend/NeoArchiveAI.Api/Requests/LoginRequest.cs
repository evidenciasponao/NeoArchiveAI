namespace NeoArchiveAI.Api.Requests.Authentication;

public sealed record LoginRequest(
    string Email,
    string Password);
