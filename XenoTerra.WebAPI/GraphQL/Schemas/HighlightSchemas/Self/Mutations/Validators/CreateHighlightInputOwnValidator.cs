using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Validators
{
    public class CreateHighlightInputOwnValidator : AbstractValidator<CreateHighlightOwnInput>
    {
        public CreateHighlightInputOwnValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.");

            RuleFor(x => x.ProfilePicturePath)
                .NotEmpty().WithMessage("ProfilePicturePath must not be empty.");
        }
    }
}
