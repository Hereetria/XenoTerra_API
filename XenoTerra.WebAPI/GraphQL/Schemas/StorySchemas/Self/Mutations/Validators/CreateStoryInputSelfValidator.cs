using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Validators
{
    public class CreateStoryInputSelfValidator : AbstractValidator<CreateStorySelfInput>
    {
        public CreateStoryInputSelfValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path must not be empty.");
        }
    }
}
