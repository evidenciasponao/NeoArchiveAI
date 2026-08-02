using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Application.OCR.Commands.ExtractText;

namespace NeoArchiveAI.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/ocr")]
public sealed class OcrController : ControllerBase
{
    private readonly ExtractTextHandler _extractTextHandler;

    public OcrController(
        ExtractTextHandler extractTextHandler)
    {
        _extractTextHandler = extractTextHandler;
    }

    [HttpPost("extract/{documentId:guid}")]
    public async Task<IActionResult> ExtractText(
        Guid documentId,
        CancellationToken cancellationToken)
    {
        var command = new ExtractTextCommand(
            documentId);

        var response = await _extractTextHandler.Handle(
            command,
            cancellationToken);

        return Ok(response);
    }
}
