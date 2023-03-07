using SampleCQRService.Infrastructure.Persistence;

namespace SampleCQRService.Commands.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryCommandRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryCommandRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task Handle(UpdateCategoryCommand message, CancellationToken cancellationToken)
    {
        Console.WriteLine("UpdateCategoryCommandHandler: Category has been updated.");
        
        var categoryToUpdate = await _categoryRepository.GetAsync(message.categoryId);
        if (categoryToUpdate == null)
        {
            return;
        }

        categoryToUpdate.Price = message.dto.NewPrice;
        categoryToUpdate.CategoryName = message.dto.CategoryName;

        _categoryRepository.Update(categoryToUpdate);

        await _categoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}