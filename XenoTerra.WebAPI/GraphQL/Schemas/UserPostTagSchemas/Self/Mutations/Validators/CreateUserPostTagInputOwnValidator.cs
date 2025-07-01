using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Validators
{
    public class CreateUserPostTagInputOwnValidator : AbstractValidator<CreateUserPostTagOwnInput>
    {
        public CreateUserPostTagInputOwnValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content must not be empty.");

            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
        }
    }
}
