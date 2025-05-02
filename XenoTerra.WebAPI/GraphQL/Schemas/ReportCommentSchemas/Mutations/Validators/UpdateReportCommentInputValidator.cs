using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Mutations.Validators
{
    public class UpdateReportCommentInputValidator : AbstractValidator<UpdateReportCommentInput>
    {
        public UpdateReportCommentInputValidator()
        {
            RuleFor(x => x.ReportCommentId)
                .NotEmpty().WithMessage("ReportCommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReportCommentId must be a valid GUID.");

            When(x => x.ReporterUserId is not null, () =>
            {
                RuleFor(x => x.ReporterUserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("ReporterUserId must be a valid GUID.");
            });

            When(x => x.CommentId is not null, () =>
            {
                RuleFor(x => x.CommentId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");
            });
        }
    }
}
