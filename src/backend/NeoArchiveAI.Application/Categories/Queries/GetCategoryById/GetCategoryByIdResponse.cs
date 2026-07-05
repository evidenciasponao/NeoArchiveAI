namespace NeoArchiveAI.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdResponse(
    Guid Id,
    string Name,
    string Description);