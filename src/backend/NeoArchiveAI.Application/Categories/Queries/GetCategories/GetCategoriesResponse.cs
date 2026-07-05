namespace NeoArchiveAI.Application.Categories.Queries.GetCategories;

public record GetCategoriesResponse(
    Guid Id,
    string Name,
    string Description);