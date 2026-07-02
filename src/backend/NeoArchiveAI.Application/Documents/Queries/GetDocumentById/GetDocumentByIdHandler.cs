using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Documents.Queries.GetDocumentById;

public class GetDocumentByIdHandler
{
    private readonly IDocumentRepository _documentRepository;

    public GetDocumentByIdHandler(
        IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<GetDocumentByIdResponse?> Handle(
        GetDocumentByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var document = await _documentRepository.GetByIdAsync(query.Id);

        if (document is null)
        {
            return null;
        }

        return new GetDocumentByIdResponse(
            document.Id,
            document.Title,
            document.Description,
            document.FileName,
            document.Extension,
            document.MimeType,
            document.Size,
            document.StoragePath,
            document.Hash,
            document.CategoryId,
            document.UploadedBy);
    }
}