namespace NeoArchiveAI.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryResponse(
    Guid Id,
    string Name,
    string Description);