using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Validators
{
    public class UpdatePostInputOwnValidator : AbstractValidator<UpdatePostOwnInput>
    {
        public UpdatePostInputOwnValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
        }
    }
}
