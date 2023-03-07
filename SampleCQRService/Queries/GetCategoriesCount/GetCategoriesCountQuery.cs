namespace SampleCQRService.Queries.GetCategoriesCount;

internal sealed record GetCategoriesCountQuery(string CategoryName) : QueryBase<int>;
