using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Validators
{
    public class CreateCommentLikeInputAdminValidator : AbstractValidator<CreateCommentLikeAdminInput>
    {
        public CreateCommentLikeInputAdminValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("CommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
