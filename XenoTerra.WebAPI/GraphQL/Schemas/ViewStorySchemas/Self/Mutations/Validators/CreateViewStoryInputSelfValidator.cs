using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Validators
{
    public class CreateViewStoryInputSelfValidator : AbstractValidator<CreateViewStorySelfInput>
    {
        public CreateViewStoryInputSelfValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");
        }
    }
}
