namespace SampleCQRService.Commands.DeleteCategory;

internal sealed record DeleteCategoryCommand(Guid categoryId) : CommandBase<bool>;
