using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations.Validators
{
    public class UpdateNotificationInputValidator : AbstractValidator<UpdateNotificationInput>
    {
        public UpdateNotificationInputValidator()
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
