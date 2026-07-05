namespace NeoArchiveAI.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand (
    string Name,
    string Description);