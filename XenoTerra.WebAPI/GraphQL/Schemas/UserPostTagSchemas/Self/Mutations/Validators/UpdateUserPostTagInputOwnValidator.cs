using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Validators
{
    public class UpdateUserPostTagInputOwnValidator : AbstractValidator<UpdateUserPostTagOwnInput>
    {
        public UpdateUserPostTagInputOwnValidator()
        {
            RuleFor(x => x.UserPostTagId)
                .NotEmpty().WithMessage("UserPostTagId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserPostTagId must be a valid GUID.");

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });
        }
    }
}
