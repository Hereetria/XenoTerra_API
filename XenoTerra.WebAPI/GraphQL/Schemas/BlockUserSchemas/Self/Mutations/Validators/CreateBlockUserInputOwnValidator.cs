using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Validators
{
    public class CreateBlockUserInputOwnValidator : AbstractValidator<CreateBlockUserOwnInput>
    {
        public CreateBlockUserInputOwnValidator()
        {
            RuleFor(x => x.BlockedUserId)
                .NotEmpty().WithMessage("BlockedUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("BlockedUserId must be a valid GUID.");
        }
    }
}
