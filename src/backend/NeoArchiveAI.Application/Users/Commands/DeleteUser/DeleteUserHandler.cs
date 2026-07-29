using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Exceptions;

namespace NeoArchiveAI.Application.Users.Commands.DeleteUser;

public sealed class DeleteUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteUserResponse> Handle(
        DeleteUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);

        if (user is null)
        {
            throw new NotFoundException(
                $"The user with id '{command.Id}' was not found.");
        }

        user.Delete();

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteUserResponse();
    }
}
