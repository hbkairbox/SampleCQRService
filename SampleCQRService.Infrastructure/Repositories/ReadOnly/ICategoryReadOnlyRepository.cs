using SampleCQRService.Infrastructure.Entities;

namespace SampleCQRService.Infrastructure.Repositories.ReadOnly;

public interface ICategoryReadOnlyRepository
{
    Category Get(string catName);
    IEnumerable<Category> GetMultiple(string catName);
    int GetCount(string catName);
}