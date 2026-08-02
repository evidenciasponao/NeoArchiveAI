using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Documents;
using NeoArchiveAI.Application.Documents.Commands.CreateDocument;
using NeoArchiveAI.Application.Documents.Commands.DeleteDocument;
using NeoArchiveAI.Application.Documents.Commands.UpdateDocument;
using NeoArchiveAI.Application.Documents.Queries.GetDocumentById;
using NeoArchiveAI.Application.Documents.Queries.GetDocuments;

namespace NeoArchiveAI.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly CreateDocumentHandler _createHandler;
    private readonly UpdateDocumentHandler _updateHandler;
    private readonly DeleteDocumentHandler _deleteHandler;
    private readonly GetDocumentByIdHandler _getByIdHandler;
    private readonly GetDocumentsHandler _getDocumentsHandler;

    public DocumentsController(
        CreateDocumentHandler createHandler,
        UpdateDocumentHandler updateHandler,
        DeleteDocumentHandler deleteHandler,
        GetDocumentByIdHandler getByIdHandler,
        GetDocumentsHandler getDocumentsHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
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
        Console.WriteLine("========================================");
        Console.WriteLine("CREATE DOCUMENT");
        Console.WriteLine("========================================");

        Console.WriteLine($"HasFormContentType: {Request.HasFormContentType}");

        if (request.File == null)
        {
            Console.WriteLine("ERROR: request.File es NULL");
            return BadRequest("El archivo no llegó.");
        }

        Console.WriteLine($"FileName: {request.File.FileName}");
        Console.WriteLine($"ContentType: {request.File.ContentType}");
        Console.WriteLine($"Length: {request.File.Length}");

        Console.WriteLine($"Title: {request.Title}");
        Console.WriteLine($"Description: {request.Description}");
        Console.WriteLine($"CategoryId: {request.CategoryId}");
        Console.WriteLine($"UploadedBy: {request.UploadedBy}");

        using var stream = request.File.OpenReadStream();

        Console.WriteLine("Stream abierto correctamente.");

        var command = new CreateDocumentCommand(
            stream,
            request.File.FileName,
            request.File.ContentType,
            request.Title,
            request.Description,
            request.CategoryId,
            request.UploadedBy);

        Console.WriteLine("Enviando al Handler...");

        var response = await _createHandler.Handle(
            command,
            cancellationToken);

        Console.WriteLine("Documento creado correctamente.");

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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteDocumentCommand(id);

        var deleted = await _deleteHandler.Handle(
            command,
            cancellationToken);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
