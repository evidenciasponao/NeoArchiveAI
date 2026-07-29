namespace NeoArchiveAI.Application.Authentication.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password);
