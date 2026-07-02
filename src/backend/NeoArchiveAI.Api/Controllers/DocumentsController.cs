using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Documents;
using NeoArchiveAI.Application.Documents.Commands.CreateDocument;
using NeoArchiveAI.Application.Documents.Commands.UpdateDocument;
using NeoArchiveAI.Application.Documents.Queries.GetDocumentById;
using NeoArchiveAI.Application.Documents.Queries.GetDocuments;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly CreateDocumentHandler _createHandler;
    private readonly UpdateDocumentHandler _updateHandler;
    private readonly GetDocumentByIdHandler _getByIdHandler;
    private readonly GetDocumentsHandler _getDocumentsHandler;

    public DocumentsController(
        CreateDocumentHandler createHandler,
        UpdateDocumentHandler updateHandler,
        GetDocumentByIdHandler getByIdHandler,
        GetDocumentsHandler getDocumentsHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getByIdHandler = getByIdHandler;
        _getDocumentsHandler = getDocumentsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken)
    {
        var query = new GetDocumentsQuery();

        var response = await _getDocumentsHandler.Handle(
            query,
            cancellationToken);

        return Ok(response);
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

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateDocumentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateDocumentCommand(
            id,
            request.Title,
            request.Description,
            request.CategoryId);

        var updated = await _updateHandler.Handle(
            command,
            cancellationToken);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
}