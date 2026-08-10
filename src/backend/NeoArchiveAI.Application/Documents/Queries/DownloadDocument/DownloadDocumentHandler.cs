using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Abstractions.Storage;

namespace NeoArchiveAI.Application.Documents.Queries.DownloadDocument;

public class DownloadDocumentHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IFileStorageService _fileStorageService;

    public DownloadDocumentHandler(
        IDocumentRepository documentRepository,
        IFileStorageService fileStorageService)
    {
        _documentRepository = documentRepository;
        _fileStorageService = fileStorageService;
    }

    public async Task<DownloadDocumentResponse?> Handle(
        DownloadDocumentQuery query,
        CancellationToken cancellationToken = default)
    {
        var document = await _documentRepository.GetByIdAsync(query.Id);

        if (document is null)
        {
            return null;
        }

        var stream = await _fileStorageService.OpenReadAsync(
            document.StoragePath,
            cancellationToken);

        return new DownloadDocumentResponse(
            stream,
            document.FileName,
            document.MimeType);
    }
}
