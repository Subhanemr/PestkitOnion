using FluentValidation;
using PestkitOnion.Application.Dtos.Employee;

namespace PestkitOnion.Application.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(x => x.departmentId).GreaterThan(0).WithMessage("DepartmentId must be greater than 0");

            RuleFor(x => x.positionId).GreaterThan(0).WithMessage("PositionId must be greater than 0");



            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 50).WithMessage("Name max characters is 2-50")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Name can only contain letters, numbers, and spaces");
            
            RuleFor(x => x.surname)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 50).WithMessage("Name max characters is 2-50")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Name can only contain letters, numbers, and spaces");
        }
    }
}
