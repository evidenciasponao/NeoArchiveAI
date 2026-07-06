using NeoArchiveAI.Domain.Common;
using NeoArchiveAI.Domain.Enums;

namespace NeoArchiveAI.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public EntityStatus Status { get; private set; }

    private Category()
    {
    }

    public Category(
        string name,
        string description)
    {
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));

        Name = name.Trim();
        Description = description.Trim();

        Status = EntityStatus.Active;
    }

    public void Update(
        string name,
        string description)
    {
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));

        Name = name.Trim();
        Description = description.Trim();

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