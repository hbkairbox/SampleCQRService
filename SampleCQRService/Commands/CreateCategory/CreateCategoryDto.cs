namespace SampleCQRService.Commands.CreateCategory;

public class CreateCategoryDto
{
    public string? CategoryName { get; set; }
    public decimal Price { get; set; }
}

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(dto => dto.CategoryName).NotNull().NotEmpty();

        RuleFor(dto => dto.Price).NotNull().NotEmpty();
    }
}
