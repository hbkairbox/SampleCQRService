using SampleCQRService.Infrastructure.Entities;
using SampleCQRService.Infrastructure.Repositories.Persistence;

namespace SampleCQRService.Commands.CreateCategory;

internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, bool>
{
    private readonly ICategoryCommandRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryCommandRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(CreateCategoryCommand message, CancellationToken cancellationToken)
    {
        Console.WriteLine("CreateCategoryCommandHandler: Category has been created.");

        var category = new Category(message.dto.CategoryName, message.dto.Price);

        _categoryRepository.Add(category);

        return await _categoryRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
    }
}