using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Documents;
using NeoArchiveAI.Application.Documents.Commands.CreateDocument;
using NeoArchiveAI.Application.Documents.Queries.GetDocumentById;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly CreateDocumentHandler _createHandler;
    private readonly GetDocumentByIdHandler _getByIdHandler;

    public DocumentsController(
        CreateDocumentHandler createHandler,
        GetDocumentByIdHandler getByIdHandler)
    {
        _createHandler = createHandler;
        _getByIdHandler = getByIdHandler;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("NeoArchiveAI API funcionando.");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetDocumentByIdQuery(id);

        var response = await _getByIdHandler.Handle(
            query,
            cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
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

        var response = await _createHandler.Handle(
            command,
            cancellationToken);

        return Ok(response);
    }
}