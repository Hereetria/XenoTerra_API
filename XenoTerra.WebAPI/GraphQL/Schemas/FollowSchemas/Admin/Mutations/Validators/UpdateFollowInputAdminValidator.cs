using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Validators
{
    public class UpdateFollowInputAdminValidator : AbstractValidator<UpdateFollowAdminInput>
    {
        public UpdateFollowInputAdminValidator()
        {
            RuleFor(x => x.FollowId)
                .NotEmpty().WithMessage("FollowId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("FollowId must be a valid GUID.");

            When(x => x.FollowerId is not null, () =>
            {
                RuleFor(x => x.FollowerId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("FollowerId must be a valid GUID.");
            });

            When(x => x.FollowingId is not null, () =>
            {
                RuleFor(x => x.FollowingId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("FollowingId must be a valid GUID.");
            });
        }
    }
}
