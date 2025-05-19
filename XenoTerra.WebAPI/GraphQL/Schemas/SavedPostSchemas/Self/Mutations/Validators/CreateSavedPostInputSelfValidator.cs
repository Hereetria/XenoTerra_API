using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Validators
{
    public class CreateSavedPostInputSelfValidator : AbstractValidator<CreateSavedPostSelfInput>
    {
        public CreateSavedPostInputSelfValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
        }
    }
}
