using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Validators
{
    public class CreateReactionInputSelfValidator : AbstractValidator<CreateReactionSelfInput>
    {
        public CreateReactionInputSelfValidator()
        {
            RuleFor(x => x.Payload)
                .NotEmpty().WithMessage("Payload must not be empty.");

            RuleFor(x => x.MessageId)
                .NotEmpty().WithMessage("MessageId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("MessageId must be a valid GUID.");
        }
    }
}
