using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Validators
{
    public class UpdateUserSettingInputAdminValidator : AbstractValidator<UpdateUserSettingAdminInput>
    {
        public UpdateUserSettingInputAdminValidator()
        {
            RuleFor(x => x.UserSettingId)
                .NotEmpty().WithMessage("UserSettingId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserSettingId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
