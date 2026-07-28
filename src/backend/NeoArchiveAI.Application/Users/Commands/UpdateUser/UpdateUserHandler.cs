using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Exceptions;
using NeoArchiveAI.Application.Users.DTOs;

namespace NeoArchiveAI.Application.Users.Commands.UpdateUser;

public sealed class UpdateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UpdateUserValidator _validator;

    public UpdateUserHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        UpdateUserValidator validator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<UpdateUserResponse> Handle(
        UpdateUserCommand command,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(
            command,
            cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group
                        .Select(error => error.ErrorMessage)
                        .ToArray());

            throw new ValidationException(errors);
        }

        var user = await _userRepository.GetByIdAsync(command.Id);

        if (user is null)
        {
            throw new NotFoundException(
                $"The user with id '{command.Id}' was not found.");
        }

        var existingUser = await _userRepository.GetByEmailAsync(command.Email);

        if (existingUser is not null &&
            existingUser.Id != command.Id)
        {
            throw new ConflictException(
                $"The email '{command.Email}' is already registered.");
        }

        user.UpdateProfile(
            command.FirstName,
            command.LastName,
            command.Email);

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.IsEmailConfirmed);

        return new UpdateUserResponse(dto);
    }
}
