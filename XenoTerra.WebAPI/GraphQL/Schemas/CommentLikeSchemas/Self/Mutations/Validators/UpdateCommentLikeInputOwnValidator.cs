using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Validators
{
    public class UpdateCommentLikeInputOwnValidator : AbstractValidator<UpdateCommentLikeOwnInput>
    {
        public UpdateCommentLikeInputOwnValidator()
        {
            RuleFor(x => x.CommentLikeId)
                .NotEmpty().WithMessage("CommentLikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentLikeId must be a valid GUID.");

            When(x => x.CommentId is not null, () =>
            {
                RuleFor(x => x.CommentId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");
            });
        }
    }
}
