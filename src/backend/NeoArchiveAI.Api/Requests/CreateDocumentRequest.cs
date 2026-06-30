using Microsoft.AspNetCore.Http;

namespace NeoArchiveAI.Api.Requests.Documents;

public class CreateDocumentRequest
{
    public IFormFile File { get; set; } = default!;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public Guid UploadedBy { get; set; }
}