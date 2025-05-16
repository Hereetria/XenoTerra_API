using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Validators
{
    public class CreateStoryHighlightInputAdminValidator : AbstractValidator<CreateStoryHighlightAdminInput>
    {
        public CreateStoryHighlightInputAdminValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            RuleFor(x => x.HighlightId)
                .NotEmpty().WithMessage("HighlightId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("HighlightId must be a valid GUID.");
        }
    }
}
