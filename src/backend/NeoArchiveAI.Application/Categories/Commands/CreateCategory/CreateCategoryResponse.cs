namespace NeoArchiveAI.Application.Categories.Commands.CreateCategory;

public record CreateCategoryResponse(
    Guid Id,
    string Name,
    string Description);