using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Validators
{
    public class CreateCommentLikeInputOwnValidator : AbstractValidator<CreateCommentLikeOwnInput>
    {
        public CreateCommentLikeInputOwnValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("CommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");
        }
    }
}
