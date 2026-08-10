using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Abstractions.Services;
using NeoArchiveAI.Application.Abstractions.Storage;
using NeoArchiveAI.Application.Exceptions;

namespace NeoArchiveAI.Application.OCR.Commands.ExtractText;

public sealed class ExtractTextHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IOcrService _ocrService;
    private readonly IUnitOfWork _unitOfWork;

    public ExtractTextHandler(
        IDocumentRepository documentRepository,
        IFileStorageService fileStorageService,
        IOcrService ocrService,
        IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _fileStorageService = fileStorageService;
        _ocrService = ocrService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ExtractTextResponse> Handle(
        ExtractTextCommand command,
        CancellationToken cancellationToken)
    {
        var document = await _documentRepository.GetByIdAsync(
            command.DocumentId);

        if (document is null)
        {
            throw new NotFoundException(
                "Document not found.");
        }

        var supportedExtensions = new[]
        {
            ".png",
            ".jpg",
            ".jpeg",
            ".bmp",
            ".tif",
            ".tiff",
            ".pdf"
        };

        if (!supportedExtensions.Contains(
                document.Extension,
                StringComparer.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"OCR does not support '{document.Extension}' files.");
        }

        await using var stream =
            await _fileStorageService.OpenReadAsync(
                document.StoragePath,
                cancellationToken);

        var extractedText =
            await _ocrService.ExtractTextAsync(
                stream,
                cancellationToken);

        document.SetExtractedText(
            extractedText);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return new ExtractTextResponse(
            document.Id,
            extractedText);
    }
}
