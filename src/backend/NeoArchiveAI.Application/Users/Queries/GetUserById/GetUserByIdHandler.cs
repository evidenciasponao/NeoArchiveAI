using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Exceptions;
using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Users.Queries.GetUserById;

public sealed class GetUserByIdHandler
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdResponse> Handle(
        GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Id);

        if (user is null)
        {
            throw new NotFoundException(
                $"The user with id '{query.Id}' was not found.");
        }

        var dto = new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.IsEmailConfirmed);

        return new GetUserByIdResponse(dto);
    }
}
