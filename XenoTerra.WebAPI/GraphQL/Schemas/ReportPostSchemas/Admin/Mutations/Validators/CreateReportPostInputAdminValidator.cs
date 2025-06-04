using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations.Validators
{
    public class CreateReportPostInputAdminValidator : AbstractValidator<CreateReportPostAdminInput>
    {
        public CreateReportPostInputAdminValidator()
        {
            RuleFor(x => x.ReporterUserId)
                .NotEmpty().WithMessage("ReporterUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReporterUserId must be a valid GUID.");

            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("CommentId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("CommentId must be a valid GUID.");

            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason must not be empty.");
        }
    }
}
