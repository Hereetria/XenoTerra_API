using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations.Validators
{
    public class CreateMediaInputValidator : AbstractValidator<CreateMediaInput>
    {
        public CreateMediaInputValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty().WithMessage("PhotoUrl must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
