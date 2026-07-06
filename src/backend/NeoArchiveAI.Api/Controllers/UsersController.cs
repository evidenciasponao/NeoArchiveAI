using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Users;
using NeoArchiveAI.Application.Users.Commands.CreateUser;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly CreateUserHandler _createHandler;

    public UsersController(CreateUserHandler createHandler)
    {
        _createHandler = createHandler;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = await _createHandler.Handle(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = response.Id },
            response);
    }
}