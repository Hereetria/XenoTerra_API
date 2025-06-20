using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Validators
{
    public class CreateStoryLikeInputAdminValidator : AbstractValidator<CreateStoryLikeAdminInput>
    {
        public CreateStoryLikeInputAdminValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
