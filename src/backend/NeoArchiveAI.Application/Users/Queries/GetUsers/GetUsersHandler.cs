using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Users.Queries.GetUsers;

public sealed class GetUsersHandler
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUsersResponse> Handle(
        GetUsersQuery query,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        var response = users
            .Select(user => new UserDto(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.IsEmailConfirmed))
            .ToList();

        return new GetUsersResponse(response);
    }
}
