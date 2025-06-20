using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Validators
{
    public class UpdateNotificationInputOwnValidator : AbstractValidator<UpdateNotificationOwnInput>
    {
        public UpdateNotificationInputOwnValidator()
        {
            RuleFor(x => x.NotificationId)
                .NotEmpty().WithMessage("NotificationId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("NotificationId must be a valid GUID.");
        }
    }
}
