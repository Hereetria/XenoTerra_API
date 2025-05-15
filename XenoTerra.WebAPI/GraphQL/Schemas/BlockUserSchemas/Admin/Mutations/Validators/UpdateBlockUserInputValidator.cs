using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Validators
{
    public class UpdateBlockUserInputValidator : AbstractValidator<UpdateBlockUserInput>
    {
        public UpdateBlockUserInputValidator()
        {
            RuleFor(x => x.BlockUserId)
                .NotEmpty().WithMessage("BlockUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("BlockUserId must be a valid GUID.");

            When(x => x.BlockingUserId is not null, () =>
            {
                RuleFor(x => x.BlockingUserId)
                    .Must(ValidationHelper.BeValidGuid)
                    .WithMessage("BlockingUserId must be a valid GUID.");
            });

            When(x => x.BlockedUserId is not null, () =>
            {
                RuleFor(x => x.BlockedUserId)
                    .Must(ValidationHelper.BeValidGuid)
                    .WithMessage("BlockedUserId must be a valid GUID.");
            });
        }
    }
}
