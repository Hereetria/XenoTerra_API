using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Validators
{
    public class CreateReactionInputValidator : AbstractValidator<CreateReactionInput>
    {
        public CreateReactionInputValidator()
        {
            RuleFor(x => x.Payload)
                .NotEmpty().WithMessage("Payload must not be empty.");

            RuleFor(x => x.MessageId)
                .NotEmpty().WithMessage("MessageId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("MessageId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
