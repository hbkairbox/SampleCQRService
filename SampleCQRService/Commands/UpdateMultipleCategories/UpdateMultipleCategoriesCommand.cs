namespace SampleCQRService.Commands.UpdateCategory;

internal sealed record UpdateMultipleCategoriesCommand(List<UpdateCategoryDto> dtos) : CommandBase;