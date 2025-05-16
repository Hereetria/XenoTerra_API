using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Validators
{
    public class UpdateCommentInputSelfValidator : AbstractValidator<UpdateCommentSelfInput>
    {
        public UpdateCommentInputSelfValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("CommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");

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
