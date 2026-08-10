namespace NeoArchiveAI.Application.Abstractions.Storage;

public interface IFileStorageService
{
    Task<string> SaveAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken = default);

    Task<Stream> OpenReadAsync(
        string storagePath,
        CancellationToken cancellationToken = default);
}
