using SampleCQRService.Infrastructure.Entities;
using SampleCQRService.Infrastructure.Repositories;

namespace SampleCQRService.Infrastructure.Repositories.Persistence
{
    public interface ICategoryCommandRepository : ICommandRepository
    {
        Category Add(Category category);
        Category Remove(Category category);
        void Update(Category category);
        Task<Category> GetAsync(Guid categoryId);
    }
}