using NeoArchiveAI.Application.Abstractions.Persistence;

namespace NeoArchiveAI.Application.Categories.Queries.GetCategories;

public class GetCategoriesHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(
        ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IReadOnlyList<GetCategoriesResponse>> Handle(
        GetCategoriesQuery query,
        CancellationToken cancellationToken = default)
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories
            .Select(x => new GetCategoriesResponse(
                x.Id,
                x.Name,
                x.Description))
            .ToList();
    }
}