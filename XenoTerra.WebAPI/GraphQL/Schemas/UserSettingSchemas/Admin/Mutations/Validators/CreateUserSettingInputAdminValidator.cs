using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Validators
{
    public class CreateUserSettingInputAdminValidator : AbstractValidator<CreateUserSettingAdminInput>
    {
        public CreateUserSettingInputAdminValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
