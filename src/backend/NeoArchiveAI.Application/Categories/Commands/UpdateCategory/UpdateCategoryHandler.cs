using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCategoryResponse?> Handle(
        UpdateCategoryCommand command,
        CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Id);

        if (category is null)
        {
            return null;
        }

        category.Update(
            command.Name,
            command.Description);

        await _categoryRepository.UpdateAsync(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateCategoryResponse(
            category.Id,
            category.Name,
            category.Description);
    }
}