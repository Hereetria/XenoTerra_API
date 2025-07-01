using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Validators
{
    public class UpdateReportCommentInputOwnValidator : AbstractValidator<UpdateReportCommentOwnInput>
    {
        public UpdateReportCommentInputOwnValidator()
        {
            RuleFor(x => x.ReportCommentId)
                .NotEmpty().WithMessage("ReportCommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReportCommentId must be a valid GUID.");

            When(x => x.CommentId is not null, () =>
            {
                RuleFor(x => x.CommentId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");
            });
        }
    }
}
