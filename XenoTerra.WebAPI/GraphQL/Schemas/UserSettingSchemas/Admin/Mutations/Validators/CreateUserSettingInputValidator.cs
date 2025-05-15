using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Validators
{
    public class CreateUserSettingInputValidator : AbstractValidator<CreateUserSettingInput>
    {
        public CreateUserSettingInputValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
