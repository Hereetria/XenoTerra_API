using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Validators
{
    public class UpdateMessageInputSelfValidator : AbstractValidator<UpdateMessageSelfInput>
    {
        public UpdateMessageInputSelfValidator()
        {
            RuleFor(x => x.MessageId)
                .NotEmpty().WithMessage("MessageId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("MessageId must be a valid GUID.");

            When(x => x.SenderId is not null, () =>
            {
                RuleFor(x => x.SenderId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("SenderId must be a valid GUID.");
            });

            When(x => x.ReceiverId is not null, () =>
            {
                RuleFor(x => x.ReceiverId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("ReceiverId must be a valid GUID.");
            });
        }
    }
}
