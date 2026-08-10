using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Application.AI.Commands.AnalyzeDocument;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/ai")]
[Authorize]
public sealed class AiController : ControllerBase
{
    private readonly AnalyzeDocumentHandler _handler;

    public AiController(
        AnalyzeDocumentHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("analyze/{documentId:guid}")]
    public async Task<ActionResult<AnalyzeDocumentResponse>> Analyze(
        Guid documentId,
        CancellationToken cancellationToken)
    {
        var response = await _handler.Handle(
            new AnalyzeDocumentCommand(documentId),
            cancellationToken);

        return Ok(response);
    }
}
