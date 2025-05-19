using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations.Validators
{
    public class UpdateViewStoryInputAdminValidator : AbstractValidator<UpdateViewStoryAdminInput>
    {
        public UpdateViewStoryInputAdminValidator()
        {
            RuleFor(x => x.ViewStoryId)
                .NotEmpty().WithMessage("ViewStoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ViewStoryId must be a valid GUID.");

            When(x => x.StoryId is not null, () =>
            {
                RuleFor(x => x.StoryId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");
            });

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
