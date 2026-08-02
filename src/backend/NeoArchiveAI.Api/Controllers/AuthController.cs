using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Authentication;
using NeoArchiveAI.Application.Authentication.Commands.Login;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly LoginHandler _loginHandler;

    public AuthController(
        LoginHandler loginHandler)
    {
        _loginHandler = loginHandler;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(
            request.Email,
            request.Password);

        var response = await _loginHandler.Handle(
            command,
            cancellationToken);

        return Ok(response);
    }
}
