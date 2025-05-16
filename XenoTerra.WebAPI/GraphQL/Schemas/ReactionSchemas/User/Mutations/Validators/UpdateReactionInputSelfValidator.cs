using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Validators
{
    public class UpdateReactionInputSelfValidator : AbstractValidator<UpdateReactionSelfInput>
    {
        public UpdateReactionInputSelfValidator()
        {
            RuleFor(x => x.ReactionId)
                .NotEmpty().WithMessage("ReactionId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReactionId must be a valid GUID.");

            When(x => x.MessageId is not null, () =>
            {
                RuleFor(x => x.MessageId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("MessageId must be a valid GUID.");
            });

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
