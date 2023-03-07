namespace SampleCQRService.Commands.UpdateCategory;

internal sealed record UpdateCategoryCommand(UpdateCategoryDto dto, Guid categoryId) : CommandBase;