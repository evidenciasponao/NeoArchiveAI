using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Users;
using NeoArchiveAI.Application.Users.Commands.CreateUser;
using NeoArchiveAI.Application.Users.Commands.DeleteUser;
using NeoArchiveAI.Application.Users.Commands.UpdateUser;
using NeoArchiveAI.Application.Users.Queries.GetUserById;
using NeoArchiveAI.Application.Users.Queries.GetUsers;

namespace NeoArchiveAI.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public sealed class UsersController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;
    private readonly UpdateUserHandler _updateUserHandler;
    private readonly DeleteUserHandler _deleteUserHandler;
    private readonly GetUsersHandler _getUsersHandler;
    private readonly GetUserByIdHandler _getUserByIdHandler;

    public UsersController(
        CreateUserHandler createUserHandler,
        UpdateUserHandler updateUserHandler,
        DeleteUserHandler deleteUserHandler,
        GetUsersHandler getUsersHandler,
        GetUserByIdHandler getUserByIdHandler)
    {
        _createUserHandler = createUserHandler;
        _updateUserHandler = updateUserHandler;
        _deleteUserHandler = deleteUserHandler;
        _getUsersHandler = getUsersHandler;
        _getUserByIdHandler = getUserByIdHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = await _createUserHandler.Handle(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = response.Id },
            response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateUserCommand(
            id,
            request.FirstName,
            request.LastName,
            request.Email);

        var response = await _updateUserHandler.Handle(
            command,
            cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);

        await _deleteUserHandler.Handle(
            command,
            cancellationToken);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(
        CancellationToken cancellationToken)
    {
        var response = await _getUsersHandler.Handle(
            new GetUsersQuery(),
            cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _getUserByIdHandler.Handle(
            new GetUserByIdQuery(id),
            cancellationToken);

        return Ok(response);
    }
}
