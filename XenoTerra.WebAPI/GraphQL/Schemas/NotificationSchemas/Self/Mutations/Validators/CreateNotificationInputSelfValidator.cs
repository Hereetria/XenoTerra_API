using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Validators
{
    public class CreateNotificationInputSelfValidator : AbstractValidator<CreateNotificationSelfInput>
    {
        public CreateNotificationInputSelfValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message must not be empty.");
        }
    }
}
