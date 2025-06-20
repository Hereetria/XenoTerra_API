using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Validators
{
    public class UpdateStoryLikeInputAdminValidator : AbstractValidator<UpdateStoryLikeAdminInput>
    {
        public UpdateStoryLikeInputAdminValidator()
        {
            RuleFor(x => x.StoryLikeId)
                .NotEmpty().WithMessage("StoryLikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryLikeId must be a valid GUID.");

            When(x => x.StoryId is not null, () =>
            {
                RuleFor(x => x.StoryId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
