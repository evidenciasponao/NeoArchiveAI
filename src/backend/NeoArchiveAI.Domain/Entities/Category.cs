using NeoArchiveAI.Domain.Enums;

namespace NeoArchiveAI.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public DocumentStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public Category(
        string name,
        string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Status = DocumentStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    private Category()
    {
    }

    public void Update(
        string name,
        string description)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        Status = DocumentStatus.Deleted;
        UpdatedAt = DateTime.UtcNow;
    }
}