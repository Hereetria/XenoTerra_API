using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Validators
{
    public class CreateNotificationInputSelfValidator : AbstractValidator<CreateNotificationSelfInput>
    {
        public CreateNotificationInputSelfValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message must not be empty.");
        }
    }
}
