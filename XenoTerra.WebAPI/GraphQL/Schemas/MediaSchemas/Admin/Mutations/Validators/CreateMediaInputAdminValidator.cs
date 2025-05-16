using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Validators
{
    public class CreateMediaInputAdminValidator : AbstractValidator<CreateMediaAdminInput>
    {
        public CreateMediaInputAdminValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty().WithMessage("PhotoUrl must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
