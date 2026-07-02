using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Documents.Commands.UpdateDocument;

public class UpdateDocumentHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDocumentHandler(
        IDocumentRepository documentRepository,
        IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateDocumentCommand command,
        CancellationToken cancellationToken = default)
    {
        var document = await _documentRepository.GetByIdAsync(command.Id);

        if (document is null)
        {
            return false;
        }

        document.UpdateInformation(
            command.Title,
            command.Description,
            command.CategoryId);

        await _documentRepository.UpdateAsync(document);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}