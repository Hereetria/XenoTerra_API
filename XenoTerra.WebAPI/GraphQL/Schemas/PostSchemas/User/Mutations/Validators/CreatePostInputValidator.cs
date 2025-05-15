using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Validators
{
    public class CreatePostInputValidator : AbstractValidator<CreatePostInput>
    {
        public CreatePostInputValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty().WithMessage("Caption must not be empty.");

            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
