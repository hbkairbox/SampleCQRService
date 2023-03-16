using SampleCQRService.Infrastructure.DBContext;
using SampleCQRService.Infrastructure.Entities;

namespace SampleCQRService.Infrastructure.Repositories.ReadOnly;

public class CategoryReadOnlyRepository : ICategoryReadOnlyRepository
{
    private readonly IReadOnlyContext _context;

    public CategoryReadOnlyRepository(IReadOnlyContext context)
    {
        _context = context;

    }

    public int GetCount(string catName)
    {
        try
        {
            return _context.Categories.Count(post => post.CategoryName == catName);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Category Get(string catName)
    {
        try
        {
            return _context.Categories.FirstOrDefault(post => post.CategoryName == catName);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<Category> GetMultiple(string catName)
    {
        try
        {
            return _context.Categories.Where(post => post.CategoryName == catName).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IQueryable<Category> GetAll()
    {
        try
        {
            return _context.Categories;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
