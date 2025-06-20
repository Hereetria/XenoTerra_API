using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Validators
{
    public class CreateReportStoryInputAdminValidator : AbstractValidator<CreateReportStoryAdminInput>
    {
        public CreateReportStoryInputAdminValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            RuleFor(x => x.ReporterUserId)
                .NotEmpty().WithMessage("ReporterUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReporterUserId must be a valid GUID.");
        }
    }
}
