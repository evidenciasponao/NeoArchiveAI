using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Categories;
using NeoArchiveAI.Application.Categories.Commands.CreateCategory;
using NeoArchiveAI.Application.Categories.Queries.GetCategories;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CreateCategoryHandler _createHandler;
    private readonly GetCategoriesHandler _getCategoriesHandler;

    public CategoriesController(
        CreateCategoryHandler createHandler,
        GetCategoriesHandler getCategoriesHandler)
    {
        _createHandler = createHandler;
        _getCategoriesHandler = getCategoriesHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(
            request.Name,
            request.Description);

        var response = await _createHandler.Handle(
            command,
            cancellationToken);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var query = new GetCategoriesQuery();

        var response = await _getCategoriesHandler.Handle(
            query,
            cancellationToken);

        return Ok(response);
    }
}