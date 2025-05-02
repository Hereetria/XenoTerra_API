using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Mutations.Validators
{
    public class CreateSavedPostInputValidator : AbstractValidator<CreateSavedPostInput>
    {
        public CreateSavedPostInputValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");

            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
        }
    }
}
