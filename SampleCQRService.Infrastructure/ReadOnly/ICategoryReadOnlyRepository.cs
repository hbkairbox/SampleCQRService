using SampleCQRService.Infrastructure.Entities;

namespace SampleCQRService.Infrastructure.ReadOnly;

public interface ICategoryReadOnlyRepository
{
    Category Get(string catName);
    IEnumerable<Category> GetMultiple(string catName);
    int GetCount(string catName);
}