using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Validators
{
    public class CreateBlockUserInputValidator : AbstractValidator<CreateBlockUserInput>
    {
        public CreateBlockUserInputValidator()
        {
            RuleFor(x => x.BlockingUserId)
                .NotEmpty().WithMessage("BlockingUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("BlockingUserId must be a valid GUID.");

            RuleFor(x => x.BlockedUserId)
                .NotEmpty().WithMessage("BlockedUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("BlockedUserId must be a valid GUID.");
        }
    }
}
