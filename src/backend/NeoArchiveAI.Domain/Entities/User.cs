using NeoArchiveAI.Domain.Common;
using NeoArchiveAI.Domain.Enums;

namespace NeoArchiveAI.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public bool IsEmailConfirmed { get; private set; }

    public DateTime? LastLoginAt { get; private set; }

    public EntityStatus Status { get; private set; }

    private User()
    {
    }

    public User(
        string firstName,
        string lastName,
        string email,
        string passwordHash)
    {
        Guard.AgainstNullOrWhiteSpace(firstName, nameof(firstName));
        Guard.AgainstNullOrWhiteSpace(lastName, nameof(lastName));
        Guard.AgainstNullOrWhiteSpace(email, nameof(email));
        Guard.AgainstNullOrWhiteSpace(passwordHash, nameof(passwordHash));

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email.Trim().ToLowerInvariant();
        PasswordHash = passwordHash;

        Status = EntityStatus.Active;
        IsEmailConfirmed = false;
    }

    public void UpdateProfile(
        string firstName,
        string lastName)
    {
        Guard.AgainstNullOrWhiteSpace(firstName, nameof(firstName));
        Guard.AgainstNullOrWhiteSpace(lastName, nameof(lastName));

        FirstName = firstName.Trim();
        LastName = lastName.Trim();

        SetUpdated();
    }

    public void ConfirmEmail()
    {
        if (IsEmailConfirmed)
            return;

        IsEmailConfirmed = true;

        SetUpdated();
    }

    public void UpdatePassword(string passwordHash)
    {
        Guard.AgainstNullOrWhiteSpace(passwordHash, nameof(passwordHash));

        PasswordHash = passwordHash;

        SetUpdated();
    }

    public void RegisterLogin()
    {
        LastLoginAt = DateTime.UtcNow;

        SetUpdated();
    }

    public void Delete()
    {
        if (Status == EntityStatus.Deleted)
            return;

        Status = EntityStatus.Deleted;

        SetUpdated();
    }
}