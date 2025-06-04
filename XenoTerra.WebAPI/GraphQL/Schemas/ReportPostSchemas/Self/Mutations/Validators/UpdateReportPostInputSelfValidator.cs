using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Validators
{
    public class UpdateReportPostInputSelfValidator : AbstractValidator<UpdateReportPostSelfInput>
    {
        public UpdateReportPostInputSelfValidator()
        {
            RuleFor(x => x.ReportPostId)
                .NotEmpty().WithMessage("ReportPostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReportPostId must be a valid GUID.");

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
