using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Validators
{
    public class CreateStoryLikeInputOwnValidator : AbstractValidator<CreateStoryLikeOwnInput>
    {
        public CreateStoryLikeInputOwnValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
