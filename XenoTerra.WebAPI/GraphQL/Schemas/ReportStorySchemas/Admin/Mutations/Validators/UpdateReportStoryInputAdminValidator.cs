using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Validators
{
    public class UpdateReportStoryInputAdminValidator : AbstractValidator<UpdateReportStoryAdminInput>
    {
        public UpdateReportStoryInputAdminValidator()
        {
            RuleFor(x => x.ReportStoryId)
                .NotEmpty().WithMessage("ReportStoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReportStoryId must be a valid GUID.");

            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            RuleFor(x => x.ReporterUserId)
                .NotEmpty().WithMessage("ReporterUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReporterUserId must be a valid GUID.");
        }
    }
}
