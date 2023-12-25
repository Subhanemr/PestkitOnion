using FluentValidation;
using PestkitOnion.Application.Dtos.Blog;

namespace PestkitOnion.Application.Validators
{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            RuleFor(x => x.authorId).GreaterThan(0).WithMessage("AuthorId must be greater than 0");
            RuleForEach(x => x.tagIds).GreaterThan(0).WithMessage("TagId must be greater than 0");
            RuleFor(x => x.tagIds).NotNull().WithMessage("Tag was not be emty");

            RuleFor(x => x.title)
                .NotEmpty().WithMessage("Title is required")
                .Length(2, 50).WithMessage("Title max characters is 2-50")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Title can only contain letters, numbers, and spaces");

            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Description is required")
                .Length(2, 1000).WithMessage("Description max characters is 2-1000")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Description can only contain letters, numbers, and spaces");
        }
    }
}
