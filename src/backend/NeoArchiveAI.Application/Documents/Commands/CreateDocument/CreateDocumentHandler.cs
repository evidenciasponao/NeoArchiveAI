using NeoArchiveAI.Application.Abstractions.Hashing;
using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Application.Abstractions.Storage;
using NeoArchiveAI.Domain.Entities;

namespace NeoArchiveAI.Application.Documents.Commands.CreateDocument;

public class CreateDocumentHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IHashService _hashService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDocumentHandler(
        IDocumentRepository documentRepository,
        IFileStorageService fileStorageService,
        IHashService hashService,
        IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _fileStorageService = fileStorageService;
        _hashService = hashService;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateDocumentResponse> Handle(
        CreateDocumentCommand command,
        CancellationToken cancellationToken = default)
    {
        // Reiniciar Stream
        command.FileStream.Position = 0;

        // Extensión
        var extension = Path.GetExtension(command.FileName)
            .ToLowerInvariant();

        // Tamaño
        var size = command.FileStream.Length;

        // Hash
        var hash = await _hashService.ComputeHashAsync(
            command.FileStream,
            cancellationToken);

        // Reiniciar Stream
        command.FileStream.Position = 0;

        // Guardar archivo
        var storagePath = await _fileStorageService.SaveAsync(
            command.FileStream,
            command.FileName,
            cancellationToken);

        // Crear entidad
        var document = new Document(
            command.Title,
            command.Description,
            command.FileName,
            extension,
            command.MimeType,
            size,
            storagePath,
            hash,
            command.CategoryId,
            command.UploadedBy);

        // Agregar al DbContext
        await _documentRepository.AddAsync(document);

        // Guardar definitivamente en PostgreSQL
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateDocumentResponse(
            document.Id,
            document.Title,
            document.FileName,
            document.StoragePath);
    }
}