using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Validators
{
    public class UpdateUserSettingInputSelfValidator : AbstractValidator<UpdateUserSettingSelfInput>
    {
        public UpdateUserSettingInputSelfValidator()
        {
            RuleFor(x => x.UserSettingId)
                .NotEmpty().WithMessage("UserSettingId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserSettingId must be a valid GUID.");
        }
    }
}
