using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Validators
{
    public class UpdatePostLikeInputOwnValidator : AbstractValidator<UpdatePostLikeOwnInput>
    {
        public UpdatePostLikeInputOwnValidator()
        {
            RuleFor(x => x.LikeId)
                .NotEmpty().WithMessage("LikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("LikeId must be a valid GUID.");

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });
        }
    }
}
