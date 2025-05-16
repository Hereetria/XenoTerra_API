using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Validators
{
    public class UpdateNotificationInputAdminValidator : AbstractValidator<UpdateNotificationAdminInput>
    {
        public UpdateNotificationInputAdminValidator()
        {
            RuleFor(x => x.NotificationId)
                .NotEmpty().WithMessage("NotificationId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("NotificationId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
