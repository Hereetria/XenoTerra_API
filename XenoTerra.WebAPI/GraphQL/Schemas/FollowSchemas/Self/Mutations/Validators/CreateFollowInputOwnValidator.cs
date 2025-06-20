using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Validators
{
    public class CreateFollowInputOwnValidator : AbstractValidator<CreateFollowOwnInput>
    {
        public CreateFollowInputOwnValidator()
        {
            RuleFor(x => x.FollowingId)
                .NotEmpty().WithMessage("FollowingId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("FollowingId must be a valid GUID.");
        }
    }
}
