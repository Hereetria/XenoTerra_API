using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Validators
{
    public class UpdateCommentLikeInputAdminValidator : AbstractValidator<UpdateCommentLikeAdminInput>
    {
        public UpdateCommentLikeInputAdminValidator()
        {
            RuleFor(x => x.CommentLikeId)
                .NotEmpty().WithMessage("CommentLikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentLikeId must be a valid GUID.");

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
