using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations.Validators
{
    public class UpdateReportStoryInputOwnValidator : AbstractValidator<UpdateReportStoryOwnInput>
    {
        public UpdateReportStoryInputOwnValidator()
        {
            RuleFor(x => x.ReportStoryId)
                .NotEmpty().WithMessage("ReportStoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReportStoryId must be a valid GUID.");

            When(x => x.StoryId is not null, () =>
            {
                RuleFor(x => x.StoryId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");
            });
        }
    }
}
