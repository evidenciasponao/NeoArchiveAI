using NeoArchiveAI.Application.Abstractions.Persistence;
using NeoArchiveAI.Domain.Entities;

namespace NeoArchiveAI.Application.Categories.Commands.CreateCategory;

public class CreateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCategoryResponse> Handle(
        CreateCategoryCommand command,
        CancellationToken cancellationToken = default)
    {
        var category = new Category(
            command.Name,
            command.Description);

        await _categoryRepository.AddAsync(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResponse(
            category.Id,
            category.Name,
            category.Description);
    }
}