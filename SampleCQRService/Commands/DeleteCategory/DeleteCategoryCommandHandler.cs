using SampleCQRService.Infrastructure.Repositories.Persistence;

namespace SampleCQRService.Commands.DeleteCategory;

internal sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryCommandRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryCommandRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<bool> Handle(DeleteCategoryCommand message, CancellationToken cancellationToken)
    {
        Console.WriteLine("DeleteCategoryCommandHandler: Category has been updated.");

        var categoryToDelete = await _categoryRepository.GetAsync(message.categoryId);
        
        if (categoryToDelete == null)
        {
            return false;
        }

        _categoryRepository.Remove(categoryToDelete);

        return await _categoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}