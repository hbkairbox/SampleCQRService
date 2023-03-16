using SampleCQRService.Infrastructure.Repositories.ReadOnly;
using SampleCQRService.Queries.GetCategoriesCount;

namespace SampleCQRService.Queries.GetCategories;

internal sealed class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<GetCategoriesResponse>>
{
    private readonly ICategoryReadOnlyRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryReadOnlyRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public Task<List<GetCategoriesResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine("GetCategoriesCountQueryHandler: Make a database call.");

        var result = _categoryRepository.GetAll();

        var response =  result.Select(x => new GetCategoriesResponse()
        {
            CategoryName = x.CategoryName,
            Price = x.Price
        }).ToList();

        return Task.FromResult(response);
    }
}

