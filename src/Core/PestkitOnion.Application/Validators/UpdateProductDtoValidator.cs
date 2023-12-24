using FluentValidation;
using PestkitOnion.Application.Dtos.Product;

namespace PestkitOnion.Application.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 50).WithMessage("Name max characters is 2-50")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Name can only contain letters, numbers, and spaces");

            RuleFor(x => x.price)
              .NotEmpty().WithMessage("Name is required")
              .LessThanOrEqualTo(999999.99m).WithMessage("Price must not be more than 999999.99")
              .GreaterThanOrEqualTo(10).WithMessage("Price must not be small be 10");

            RuleFor(x => x.description).MaximumLength(1000).WithMessage("Decription max characters is 1000");
        }
    }
}
