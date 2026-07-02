namespace NeoArchiveAI.Api.Requests.Documents;

public class UpdateDocumentRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
}