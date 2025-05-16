using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Validators
{
    public class CreateStoryInputSelfValidator : AbstractValidator<CreateStorySelfInput>
    {
        public CreateStoryInputSelfValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
