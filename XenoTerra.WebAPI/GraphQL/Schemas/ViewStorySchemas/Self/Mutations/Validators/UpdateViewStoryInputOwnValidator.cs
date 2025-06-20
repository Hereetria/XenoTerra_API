using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Validators
{
    public class UpdateViewStoryInputOwnValidator : AbstractValidator<UpdateViewStoryOwnInput>
    {
        public UpdateViewStoryInputOwnValidator()
        {
            RuleFor(x => x.ViewStoryId)
                .NotEmpty().WithMessage("ViewStoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ViewStoryId must be a valid GUID.");

            When(x => x.StoryId is not null, () =>
            {
                RuleFor(x => x.StoryId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");
            });
        }
    }
}
