namespace NeoArchiveAI.Application.Abstractions.Storage;

public interface IFileStorageService
{
    Task<string> SaveAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken = default);
}
