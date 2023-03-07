namespace SampleCQRService.Commands.CreateCategory;

internal sealed record CreateCategoryCommand(CreateCategoryDto dto) : CommandBase<bool>;
