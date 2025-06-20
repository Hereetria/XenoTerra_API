using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Validators
{
    public class UpdateStoryLikeInputOwnValidator : AbstractValidator<UpdateStoryLikeOwnInput>
    {
        public UpdateStoryLikeInputOwnValidator()
        {
            RuleFor(x => x.StoryLikeId)
                .NotEmpty().WithMessage("StoryLikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryLikeId must be a valid GUID.");

            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
