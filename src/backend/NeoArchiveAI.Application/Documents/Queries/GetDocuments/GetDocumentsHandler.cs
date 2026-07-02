using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Documents.Queries.GetDocuments;

public class GetDocumentsHandler
{
    private readonly IDocumentRepository _documentRepository;

    public GetDocumentsHandler(
        IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<IReadOnlyList<GetDocumentsResponse>> Handle(
        GetDocumentsQuery query,
        CancellationToken cancellationToken = default)
    {
        var documents = await _documentRepository.GetAllAsync();

        return documents
            .Select(document => new GetDocumentsResponse(
                document.Id,
                document.Title,
                document.FileName,
                document.Extension,
                document.Size,
                document.CreatedAt))
            .ToList();
    }
}