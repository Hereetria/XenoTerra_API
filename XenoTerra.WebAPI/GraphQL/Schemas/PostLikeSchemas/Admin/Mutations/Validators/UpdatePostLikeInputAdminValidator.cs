using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Validators
{
    public class UpdatePostLikeInputAdminValidator : AbstractValidator<UpdatePostLikeAdminInput>
    {
        public UpdatePostLikeInputAdminValidator()
        {
            RuleFor(x => x.PostLikeId)
                .NotEmpty().WithMessage("PostLikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostLikeId must be a valid GUID.");

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
