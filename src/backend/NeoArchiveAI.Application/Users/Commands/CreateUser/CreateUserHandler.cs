using NeoArchiveAI.Application.Abstractions.Hashing;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Exceptions;
using NeoArchiveAI.Domain.Entities;

namespace NeoArchiveAI.Application.Users.Commands.CreateUser;

public sealed class CreateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateUserValidator _validator;

    public CreateUserHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork,
        CreateUserValidator validator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<CreateUserResponse> Handle(
        CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(command, cancellationToken);

        if (!validation.IsValid)
        {
            var errors = validation.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage).ToArray());

            throw new ValidationException(errors);
        }

        var existingUser = await _userRepository.GetByEmailAsync(command.Email);

        if (existingUser is not null)
        {
            throw new ConflictException(
                $"The email '{command.Email}' is already registered.");
        }

        var passwordHash = _passwordHasher.Hash(command.Password);

        var user = new User(
            command.FirstName,
            command.LastName,
            command.Email,
            passwordHash);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.IsEmailConfirmed);
    }
}
