using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Validators
{
    public class CreateNotificationInputOwnValidator : AbstractValidator<CreateNotificationOwnInput>
    {
        public CreateNotificationInputOwnValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message must not be empty.");
        }
    }
}
