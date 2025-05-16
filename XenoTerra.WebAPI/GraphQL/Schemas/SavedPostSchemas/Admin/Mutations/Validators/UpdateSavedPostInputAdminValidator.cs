using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Validators
{
    public class UpdateSavedPostInputAdminValidator : AbstractValidator<UpdateSavedPostAdminInput>
    {
        public UpdateSavedPostInputAdminValidator()
        {
            RuleFor(x => x.SavedPostId)
                .NotEmpty().WithMessage("SavedPostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("SavedPostId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });
        }
    }
}
