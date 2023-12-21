using FluentValidation;
using PestkitOnion.Application.Dtos.Position;

namespace PestkitOnion.Application.Validators
{
    public class UpdatePositionDtoValidator : AbstractValidator<UpdatePositionDto>
    {
        public UpdatePositionDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 50).WithMessage("Name max characters is 2-50")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Name can only contain letters, numbers, and spaces");
        }
    }
}
