using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Validators
{
    public class UpdateStoryInputOwnValidator : AbstractValidator<UpdateStoryOwnInput>
    {
        public UpdateStoryInputOwnValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");
        }
    }
}
