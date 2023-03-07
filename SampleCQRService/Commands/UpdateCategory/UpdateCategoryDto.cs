namespace SampleCQRService.Commands.UpdateCategory;

public class UpdateCategoryDto
{
    public string? CategoryName { get; set; }
    public decimal NewPrice { get; set; }
}

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(dto => dto.CategoryName).NotNull().NotEmpty();

        RuleFor(dto => dto.NewPrice).NotNull().NotEmpty().GreaterThan(decimal.Zero);
    }
}