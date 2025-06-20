using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Validators
{
    public class UpdateMessageInputOwnValidator : AbstractValidator<UpdateMessageOwnInput>
    {
        public UpdateMessageInputOwnValidator()
        {
            RuleFor(x => x.MessageId)
                .NotEmpty().WithMessage("MessageId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("MessageId must be a valid GUID.");

            When(x => x.ReceiverId is not null, () =>
            {
                RuleFor(x => x.ReceiverId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("ReceiverId must be a valid GUID.");
            });
        }
    }
}
