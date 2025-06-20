using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Validators
{
    public class UpdateReactionInputOwnValidator : AbstractValidator<UpdateReactionOwnInput>
    {
        public UpdateReactionInputOwnValidator()
        {
            RuleFor(x => x.ReactionId)
                .NotEmpty().WithMessage("ReactionId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReactionId must be a valid GUID.");

            When(x => x.MessageId is not null, () =>
            {
                RuleFor(x => x.MessageId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("MessageId must be a valid GUID.");
            });
        }
    }
}
