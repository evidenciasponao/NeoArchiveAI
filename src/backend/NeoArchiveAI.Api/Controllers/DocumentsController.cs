using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Documents;
using NeoArchiveAI.Application.Documents.Commands.CreateDocument;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly CreateDocumentHandler _handler;

    public DocumentsController(CreateDocumentHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("NeoArchiveAI API funcionando.");
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromForm] CreateDocumentRequest request,
        CancellationToken cancellationToken)
    {
        using var stream = request.File.OpenReadStream();

        var command = new CreateDocumentCommand(
            stream,
            request.File.FileName,
            request.File.ContentType,
            request.Title,
            request.Description,
            request.CategoryId,
            request.UploadedBy);

        var response = await _handler.Handle(
            command,
            cancellationToken);

        return Ok(response);
    }
}