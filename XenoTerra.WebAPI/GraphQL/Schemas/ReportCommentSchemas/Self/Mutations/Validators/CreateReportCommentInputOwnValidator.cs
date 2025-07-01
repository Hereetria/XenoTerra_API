using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Validators
{
    public class CreateReportCommentInputOwnValidator : AbstractValidator<CreateReportCommentOwnInput>
    {
        public CreateReportCommentInputOwnValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("CommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");
        }
    }
}
