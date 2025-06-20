using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Validators
{
    public class CreateMessageInputOwnValidator : AbstractValidator<CreateMessageOwnInput>
    {
        public CreateMessageInputOwnValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content must not be empty.");

            RuleFor(x => x.ReceiverId)
                .NotEmpty().WithMessage("ReceiverId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReceiverId must be a valid GUID.");
        }
    }
}
