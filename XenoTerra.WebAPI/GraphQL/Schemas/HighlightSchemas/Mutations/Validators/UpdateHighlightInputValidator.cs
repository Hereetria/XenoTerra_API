using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations.Validators
{
    public class UpdateHighlightInputValidator : AbstractValidator<UpdateHighlightInput>
    {
        public UpdateHighlightInputValidator()
        {
            RuleFor(x => x.HighlightId)
                .NotEmpty().WithMessage("HighlightId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("HighlightId must be a valid GUID.");
        }
    }
}
