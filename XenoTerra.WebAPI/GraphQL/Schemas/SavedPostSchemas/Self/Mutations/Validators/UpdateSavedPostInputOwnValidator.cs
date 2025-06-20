using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Validators
{
    public class UpdateSavedPostInputOwnValidator : AbstractValidator<UpdateSavedPostOwnInput>
    {
        public UpdateSavedPostInputOwnValidator()
        {
            RuleFor(x => x.SavedPostId)
                .NotEmpty().WithMessage("SavedPostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("SavedPostId must be a valid GUID.");

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });
        }
    }
}
