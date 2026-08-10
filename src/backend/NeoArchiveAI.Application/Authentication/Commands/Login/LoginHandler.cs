using NeoArchiveAI.Application.Abstractions.Hashing;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Abstractions.Services;
using NeoArchiveAI.Application.Users.DTOs;
using NeoArchiveAI.Domain.Enums;

namespace NeoArchiveAI.Application.Authentication.Commands.Login;

public sealed class LoginHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand command,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);

        if (user is null)
            throw new UnauthorizedAccessException("Invalid email or password.");

        if (user.Status != EntityStatus.Active)
            throw new UnauthorizedAccessException("User account is inactive.");

        var isValidPassword = _passwordHasher.Verify(
            command.Password,
            user.PasswordHash);

        if (!isValidPassword)
            throw new UnauthorizedAccessException("Invalid email or password.");

        user.RegisterLogin();

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accessToken = _jwtService.GenerateToken(user);

        var expiresAt = _jwtService.GetExpiration();

        var userDto = new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.IsEmailConfirmed);

        return new LoginResponse(
            accessToken,
            expiresAt,
            userDto);
    }
}
