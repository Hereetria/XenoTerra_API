using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Validators
{
    public class CreateCommentInputValidator : AbstractValidator<CreateCommentInput>
    {
        public CreateCommentInputValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content must not be empty.");

            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
