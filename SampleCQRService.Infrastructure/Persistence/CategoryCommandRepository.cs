using Microsoft.EntityFrameworkCore;
using SampleCQRService.Infrastructure.DBContext;
using SampleCQRService.Infrastructure.Entities;
using SampleCQRService.Infrastructure.Repositories;

namespace SampleCQRService.Infrastructure.Persistence;

public class CategoryCommandRepository : ICategoryCommandRepository
{
    private readonly Context _writeDbContext;

    public IUnitOfWork UnitOfWork => _writeDbContext;

    public CategoryCommandRepository(Context writeDbContext)
    {
        _writeDbContext = writeDbContext ?? throw new ArgumentNullException(nameof(writeDbContext));
    }

    public Category Add(Category category)
    {
        return _writeDbContext.Categories.Add(category).Entity;
    }

    public Category Remove(Category category)
    {
        return _writeDbContext.Categories.Remove(category).Entity;

    }

    public async Task<Category> GetAsync(Guid categoryId)
    {
        var category = await _writeDbContext
                            .Categories
                            .SingleOrDefaultAsync(o => o.Id == categoryId);
        
        if (category == null)
        {
            category = _writeDbContext
                        .Categories
                        .Local
                        .FirstOrDefault(o => o.Id == categoryId);
        }

        if (category != null)
        {
            // This is to load Relationship rows (1-M & 1-1)
            //await _writeDbContext.Entry(category)
            //    .Collection(i => i.CategoryItems).LoadAsync();
            //await _writeDbContext.Entry(category)
            //    .Reference(i => i.CategoryStatus).LoadAsync();
        }

        return category;
    }

    public void Update(Category category)
    {
        _writeDbContext.Entry(category).State = EntityState.Modified;
    }
}
