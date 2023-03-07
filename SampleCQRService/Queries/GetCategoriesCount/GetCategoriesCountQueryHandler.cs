using SampleCQRService.Infrastructure.Repositories.ReadOnly;

namespace SampleCQRService.Queries.GetCategoriesCount;

internal sealed class GetCategoriesCountQueryHandler : IQueryHandler<GetCategoriesCountQuery, int>
{
    private readonly ICategoryReadOnlyRepository _categoryRepository;

    public GetCategoriesCountQueryHandler(ICategoryReadOnlyRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public Task<int> Handle(GetCategoriesCountQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine("GetCategoriesCountQueryHandler: Make a database call.");

        var result = _categoryRepository.GetCount(request.CategoryName);

        return Task.FromResult(result);
    }
}
