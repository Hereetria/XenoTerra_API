using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Validators
{
    public class UpdateBlockUserInputOwnValidator : AbstractValidator<UpdateBlockUserOwnInput>
    {
        public UpdateBlockUserInputOwnValidator()
        {
            RuleFor(x => x.BlockUserId)
                .NotEmpty().WithMessage("BlockUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("BlockUserId must be a valid GUID.");


            When(x => x.BlockedUserId is not null, () =>
            {
                RuleFor(x => x.BlockedUserId)
                    .Must(ValidationHelper.BeValidGuid)
                    .WithMessage("BlockedUserId must be a valid GUID.");
            });
        }
    }
}
