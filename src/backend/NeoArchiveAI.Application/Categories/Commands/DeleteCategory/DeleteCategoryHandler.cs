using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteCategoryResponse?> Handle(
        DeleteCategoryCommand command,
        CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Id);

        if (category is null)
        {
            return null;
        }

        category.Delete();

        await _categoryRepository.UpdateAsync(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryResponse(category.Id);
    }
}