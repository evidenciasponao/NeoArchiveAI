using NeoArchiveAI.Domain.Common;
using NeoArchiveAI.Domain.Enums;

namespace NeoArchiveAI.Domain.Entities;

public class Document : BaseEntity
{
    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string FileName { get; private set; } = string.Empty;

    public string Extension { get; private set; } = string.Empty;

    public string MimeType { get; private set; } = string.Empty;

    public long Size { get; private set; }

    public string StoragePath { get; private set; } = string.Empty;

    public string Hash { get; private set; } = string.Empty;

    public Guid CategoryId { get; private set; }

    public Guid UploadedBy { get; private set; }

    public DocumentStatus Status { get; private set; }

    private Document()
    {
    }

    public Document(
        string title,
        string description,
        string fileName,
        string extension,
        string mimeType,
        long size,
        string storagePath,
        string hash,
        Guid categoryId,
        Guid uploadedBy)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(title));
        Guard.AgainstNullOrWhiteSpace(fileName, nameof(fileName));
        Guard.AgainstNegativeOrZero(size, nameof(size));
        Guard.AgainstEmptyGuid(categoryId, nameof(categoryId));
        Guard.AgainstEmptyGuid(uploadedBy, nameof(uploadedBy));

        Title = title.Trim();
        Description = description.Trim();
        FileName = fileName.Trim();
        Extension = extension.Trim().ToLowerInvariant();
        MimeType = mimeType.Trim();
        Size = size;
        StoragePath = storagePath.Trim();
        Hash = hash.Trim();
        CategoryId = categoryId;
        UploadedBy = uploadedBy;
        Status = DocumentStatus.Active;
    }

    public void UpdateInformation(
        string title,
        string description,
        Guid categoryId)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(title));
        Guard.AgainstEmptyGuid(categoryId, nameof(categoryId));

        Title = title.Trim();
        Description = description.Trim();
        CategoryId = categoryId;

        SetUpdated();
    }

    public void Archive()
    {
        if (Status == DocumentStatus.Archived)
            return;

        Status = DocumentStatus.Archived;

        SetUpdated();
    }

    public void Restore()
    {
        if (Status == DocumentStatus.Active)
            return;

        Status = DocumentStatus.Active;

        SetUpdated();
    }

    public void Delete()
    {
        if (Status == DocumentStatus.Deleted)
            return;

        Status = DocumentStatus.Deleted;

        SetUpdated();
    }
}