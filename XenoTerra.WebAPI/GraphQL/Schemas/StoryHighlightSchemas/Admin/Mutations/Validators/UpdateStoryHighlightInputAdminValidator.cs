using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Validators
{
    public class UpdateStoryHighlightInputAdminValidator : AbstractValidator<UpdateStoryHighlightAdminInput>
    {
        public UpdateStoryHighlightInputAdminValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            When(x => x.HighlightId is not null, () =>
            {
                RuleFor(x => x.HighlightId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("HighlightId must be a valid GUID.");
            });
        }
    }
}
