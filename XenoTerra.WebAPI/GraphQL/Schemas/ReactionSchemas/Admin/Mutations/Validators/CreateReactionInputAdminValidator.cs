using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Validators
{
    public class CreateReactionInputAdminValidator : AbstractValidator<CreateReactionAdminInput>
    {
        public CreateReactionInputAdminValidator()
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
