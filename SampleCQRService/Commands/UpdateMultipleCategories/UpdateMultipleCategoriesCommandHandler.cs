using SampleCQRService.Infrastructure.Repositories.Persistence;

namespace SampleCQRService.Commands.UpdateCategory;

internal sealed class UpdateMultipleCategoriesCommandHandler : ICommandHandler<UpdateMultipleCategoriesCommand>
{
    private readonly ICategoryCommandRepository _categoryRepository;

    public UpdateMultipleCategoriesCommandHandler(ICategoryCommandRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(UpdateMultipleCategoriesCommand message, CancellationToken cancellationToken)
    {
        Console.WriteLine("UpdateCategoryCommandHandler: Category has been updated.");
        
        //var categoryToUpdate = await _categoryRepository.GetAsync(message.categoryId);
        //if (categoryToUpdate == null)
        //{
        //    return;
        //}

        //categoryToUpdate.Price = message.dto.NewPrice;
        //categoryToUpdate.CategoryName = message.dto.CategoryName;

        //_categoryRepository.Update(categoryToUpdate);

        //await _categoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        await Task.FromResult(0);
    }
}