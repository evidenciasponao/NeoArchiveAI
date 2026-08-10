using NeoArchiveAI.Application.Abstractions.Storage;

namespace NeoArchiveAI.Infrastructure.Storage;

public class LocalFileStorageService : IFileStorageService
{
    public async Task<string> SaveAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken = default)
    {
        var today = DateTime.UtcNow;

        var relativeFolder = Path.Combine(
            today.Year.ToString(),
            today.Month.ToString("00"),
            today.Day.ToString("00"));

        var uploadsFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Storage",
            relativeFolder);

        Directory.CreateDirectory(uploadsFolder);

        var extension = Path.GetExtension(fileName);

        var storedFileName = $"{Guid.NewGuid()}{extension}";

        var fullPath = Path.Combine(
            uploadsFolder,
            storedFileName);

        await using var fileStream = new FileStream(
            fullPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None);

        await stream.CopyToAsync(fileStream, cancellationToken);

        return Path.Combine(relativeFolder, storedFileName)
            .Replace("\\", "/");
    }

    public Task<Stream> OpenReadAsync(
        string storagePath,
        CancellationToken cancellationToken = default)
    {
        var fullPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Storage",
            storagePath.Replace("/", Path.DirectorySeparatorChar.ToString()));

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException(
                "Stored file was not found.",
                fullPath);
        }

        Stream stream = new FileStream(
            fullPath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read);

        return Task.FromResult(stream);
    }
}
