using Microsoft.AspNetCore.Mvc;
using NeoArchiveAI.Api.Requests.Categories;
using NeoArchiveAI.Application.Categories.Commands.CreateCategory;
using NeoArchiveAI.Application.Categories.Queries.GetCategories;
using NeoArchiveAI.Application.Categories.Queries.GetCategoryById;

namespace NeoArchiveAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CreateCategoryHandler _createHandler;
    private readonly GetCategoriesHandler _getCategoriesHandler;
    private readonly GetCategoryByIdHandler _getCategoryByIdHandler;

    public CategoriesController(
        CreateCategoryHandler createHandler,
        GetCategoriesHandler getCategoriesHandler,
        GetCategoryByIdHandler getCategoryByIdHandler)
    {
        _createHandler = createHandler;
        _getCategoriesHandler = getCategoriesHandler;
        _getCategoryByIdHandler = getCategoryByIdHandler;
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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);

        var response = await _getCategoryByIdHandler.Handle(
            query,
            cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}