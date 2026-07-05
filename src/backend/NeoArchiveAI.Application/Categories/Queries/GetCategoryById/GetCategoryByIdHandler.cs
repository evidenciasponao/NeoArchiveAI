using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(
        ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryByIdResponse?> Handle(
        GetCategoryByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(query.Id);

        if (category is null)
        {
            return null;
        }

        return new GetCategoryByIdResponse(
            category.Id,
            category.Name,
            category.Description);
    }
}