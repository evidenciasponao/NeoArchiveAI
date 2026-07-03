using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentHandler(
        IDocumentRepository documentRepository,
        IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteDocumentCommand command,
        CancellationToken cancellationToken = default)
    {
        // Buscar documento
        var document = await _documentRepository.GetByIdAsync(command.Id);

        if (document is null)
        {
            return false;
        }

        // Eliminación lógica
        document.Delete();

        // Marcar entidad como modificada
        await _documentRepository.UpdateAsync(document);

        // Guardar cambios
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}