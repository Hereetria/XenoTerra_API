using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Validators
{
    public class CreatePostInputSelfValidator : AbstractValidator<CreatePostSelfInput>
    {
        public CreatePostInputSelfValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty().WithMessage("Caption must not be empty.");

            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path must not be empty.");
        }
    }
}
